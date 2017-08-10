namespace GreatWall.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GreatWall.Client.SaleLogger;
    using GreatWall.Client.StaticData;
    using GreatWall.Entities.Entities.Console;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Console;
    using GreatWall.Entities.Interfaces.Repository;

    public class Engine
    {
        private string browseOrAdd;
        private string[] menuItems;
        private IRepository productRepository;

        public Engine(IRepository productRepository)
        {
            this.menuItems = new string[]
            {
                "Add Product",
                "Browse Products",
                "About",
                "Exit"
            };
            this.Writer = new ConsoleWriter();
            this.Reader = new ConsoleReader();
            this.Color = new ConsoleColour();
            this.Cursor = new ConsoleCursor();
            this.productRepository = productRepository;
        }

        public IWriter Writer { get; private set; }

        public IReader Reader { get; private set; }

        public IColor Color { get; private set; }

        public ICursor Cursor { get; private set; }

        public void Run()
        {
            this.ConsoleSize();
            try
            {
                this.ShowMenu(this.menuItems, "mainMenu");
            }
            catch (Exception e)
            {
                this.Color.ForegroundColor(ConsoleColor.Red);
                this.Writer.WriteLine(e.Message);
                Console.ReadKey();
                this.Run();
            }
        }

        private void ShowMenu(IList<string> list, string menu, params int[] categoryNumber)
        {
            int pageSize = list.Count;
            int pointer = 1;

            while (true)
            {
                this.Cursor.CursorVisible(false);
                this.Color.BackgroundColor(ConsoleColor.Black);
                this.Color.ForegroundColor(ConsoleColor.Yellow);

                this.Cursor.Clear();
                this.Cursor.SetCursorPosition(0, 0);
                this.Writer.Write(Constants.Logo);
                this.Cursor.CursorTop(8);
                this.Cursor.CursorLeft(10);

                if (menu == "mainMenu") this.Writer.WriteLine("MAIN MENU");
                else if (menu == "subCategory") this.Writer.WriteLine("CATEGORIES:");
                else if (menu == "addProduct" || menu == "browse") this.Writer.WriteLine("SUBCATEGORIES:");

                int current = 1;
                this.Cursor.CursorTop(10);
                foreach (var item in list)
                {
                    this.Color.BackgroundColor(ConsoleColor.Black);
                    this.Color.ForegroundColor(ConsoleColor.White);
                    if (current == pointer)
                    {
                        this.Color.BackgroundColor(ConsoleColor.White);
                        this.Color.ForegroundColor(ConsoleColor.Black);
                    }

                    current++;
                    this.Cursor.CursorLeft(10);
                    this.Writer.WriteLine(item);
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        this.ShowOtherMenu(pointer, menu, categoryNumber);
                        break;
                    case ConsoleKey.UpArrow:
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (pointer <= 1)
                        {
                            pointer = list.Count;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer < pageSize)
                        {
                            pointer++;
                        }
                        else if (pointer >= pageSize)
                        {
                            pointer = 1;
                        }

                        break;
                    case ConsoleKey.Escape:
                        this.ShowMenu(this.menuItems, "mainMenu");
                        break;
                }
            }
        }

        private void ShowOtherMenu(int currentSelection, string menu, params int[] categoryNumber)
        {
            if (menu == "mainMenu")
            {
                if (currentSelection == 1 || currentSelection == 2)
                {
                    this.browseOrAdd = currentSelection == 1 ? "addProduct" : "browse";
                    string[] categories = Enum.GetNames(typeof(Category));
                    this.LoginForAddingProduct();
                    this.ShowMenu(categories, "subCategory", currentSelection);
                }
                else if (currentSelection == 4)
                {
                    Environment.Exit(0);
                }
            }
            else if (menu == "subCategory")
            {
                this.SelectSubCategories(currentSelection, this.browseOrAdd);
            }
            else if (menu == "addProduct")
            {
                this.Cursor.CursorVisible(false);
                this.Color.BackgroundColor(ConsoleColor.Black);
                this.Color.ForegroundColor(ConsoleColor.White);
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                this.PrintHeadLine(category.ToString(), subCategory.ToString());
                this.productRepository.AddProduct(category, subCategory);

                this.Color.ForegroundColor(ConsoleColor.Green);
                this.Writer.WriteLine(Constants.SuccesfullyAddedProduct);
                this.Writer.WriteLine(Constants.PreeAnyKeyToContinue);
                Console.ReadKey();

                this.Run();
            }
            else if (menu == "browse")
            {
                this.Cursor.CursorVisible(false);
                this.Color.BackgroundColor(ConsoleColor.Black);
                this.Color.ForegroundColor(ConsoleColor.White);
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                this.BrowseProducts(category, subCategory);
            }
        }

        private void LoginForAddingProduct()
        {
            if (this.browseOrAdd == "addProduct")
            {
                this.Writer.Write("Enter username: ");
                string userName = this.Reader.ReadLine();
                this.Writer.Write("Enter password: ");
                string password = this.Reader.ReadLine();

                if (userName != Constants.AdminUsername || password != Constants.AdminPassword)
                {
                    this.Color.ForegroundColor(ConsoleColor.Red);
                    throw new InvalidUsernamerOrPasswordException();
                }

                this.Color.ForegroundColor(ConsoleColor.Green);
                this.Writer.Write(Constants.SuccessLogin);
                Console.ReadKey();
            }
        }

        private void BrowseProducts(Category category, SubCategory subCategory)
        {
            IList<IProduct> products = this.productRepository.GetProductData(subCategory);

            int pageSize = 7;
            int currentPage = 0;
            int maxPages = (int)Math.Ceiling(products.Count() / (double)pageSize);
            int pointer = 1;

            this.Writer.WriteLine($"Products in Category: {category.ToString()}, SubCategory: {subCategory.ToString()}");
            StringBuilder sb = new StringBuilder();
            string horizontalLine = new string(Constants.HorizontalLine, 10);
            sb.Append(horizontalLine)
                .Append(Constants.CrossSign)
                .Append(horizontalLine + new string(Constants.HorizontalLine, 2))
                .Append(Constants.CrossSign)
                .Append(horizontalLine)
                .Append(Constants.CrossSign)
                .Append(horizontalLine)
                .Append(Constants.CrossSign);

            while (true)
            {
                this.Color.BackgroundColor(ConsoleColor.Black);
                this.Color.ForegroundColor(ConsoleColor.Yellow);
                this.Cursor.Clear();
                this.Writer.WriteLine($" Model    {Constants.VerticalLine}Manufacturer{Constants.VerticalLine} Price    {Constants.VerticalLine} Quantity {Constants.VerticalLine} (Page {currentPage + 1} of {maxPages})");
                this.Writer.WriteLine(sb.ToString());
                bool hasProductsInCategory = false;
                int current = 1;

                foreach (var product in products
                                            .Skip(pageSize * currentPage)
                                            .Take(pageSize))
                {
                    this.Color.BackgroundColor(ConsoleColor.Black);
                    this.Color.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.Color.BackgroundColor(ConsoleColor.Yellow);
                        this.Color.ForegroundColor(ConsoleColor.Black);
                    }

                    this.Writer.WriteLine($"{(product.Model.Length > 10 ? product.Model.Substring(0, 10) : product.Model),10 }{Constants.VerticalLine}{product.Manufacturer,12}{Constants.VerticalLine}{product.Price,10}{Constants.VerticalLine}{product.Quantity,10}{Constants.VerticalLine}");
                    hasProductsInCategory = true;
                    current++;
                }

                if (!hasProductsInCategory)
                {
                    this.Writer.WriteLine(Constants.NoProductInCategory);
                    this.Writer.WriteLine(Constants.PreeAnyKeyToContinue);
                    Console.ReadKey();
                    this.Run();
                }

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        IProduct currentProduct = products
                            .Skip((pageSize * currentPage) + pointer - 1)
                            .FirstOrDefault();
                        this.ShowDetails(currentProduct);
                        break;
                    case ConsoleKey.UpArrow:
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (currentPage > 0)
                        {
                            currentPage--;
                            pointer = pageSize;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer < pageSize)
                        {
                            pointer++;
                        }
                        else if (currentPage + 1 < maxPages)
                        {
                            currentPage++;
                            pointer = 1;
                        }

                        break;
                    case ConsoleKey.Escape:
                        this.Run();
                        break;
                }
            }
        }

        private void ShowDetails(IProduct currentProduct)
        {
            this.Color.BackgroundColor(ConsoleColor.Black);
            this.Color.ForegroundColor(ConsoleColor.Yellow);
            this.Cursor.Clear();
            this.DrawDetailsView();
            this.Cursor.SetCursorPosition(0, 1);
            this.Writer.WriteLine(currentProduct.ToString());

            this.ShowDetailsMenu(currentProduct);
        }

        private void ShowDetailsMenu(IProduct currentProduct)
        {
            IList<string> detailsMenu = new List<string>
            {
                "Buy product",
                "Back"
            };
            int pointer = 1;
            while (true)
            {
                this.Cursor.SetCursorPosition(5, 20);
                int current = 1;
                foreach (var menuItem in detailsMenu)
                {
                    this.Color.BackgroundColor(ConsoleColor.Black);
                    this.Color.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.Color.BackgroundColor(ConsoleColor.Yellow);
                        this.Color.ForegroundColor(ConsoleColor.Black);
                    }

                    current++;
                    this.Cursor.CursorLeft(5);
                    this.Writer.WriteLine(menuItem);
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        if (pointer == 2)
                        {
                            return;
                        }
                        else
                        {
                            IList<string> customerDetails = GetCustomerDetails();
                            this.SaleProduct(customerDetails, currentProduct);
                            return;
                        }

                    case ConsoleKey.UpArrow:
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (pointer <= 1)
                        {
                            pointer = detailsMenu.Count;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer < detailsMenu.Count)
                        {
                            pointer++;
                        }
                        else if (pointer >= detailsMenu.Count)
                        {
                            pointer = 1;
                        }

                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        private void SaleProduct(IList<string> customerDetails, IProduct currentProduct)
        {
            int customerWantedQuantity = int.Parse(customerDetails[3]);
            if (customerWantedQuantity > currentProduct.Quantity)
            {
                throw new NotEnoughProductsException();
            }

            this.productRepository.AddClient(customerDetails, currentProduct);
            this.productRepository.RemoveProduct(currentProduct, customerWantedQuantity);

            Logger.ExportPdfLog(customerDetails, currentProduct);
            this.Color.ForegroundColor(ConsoleColor.Green);
            this.Writer.WriteLine(Constants.SuccessfullyPlacedOrder);
            Console.ReadKey();

            this.Run();
        }

        private IList<string> GetCustomerDetails()
        {
            this.Cursor.Clear();
            this.DrawDetailsView();
            this.Cursor.CursorTop(1);
            IList<string> customerDetails = new List<string>();
            this.Writer.Write("Enter name: ");
            customerDetails.Add(this.Reader.ReadLine());
            this.Writer.Write("Enter address for delivery: ");
            customerDetails.Add(this.Reader.ReadLine());
            this.Writer.Write("Telephone number: ");
            customerDetails.Add(this.Reader.ReadLine());
            this.Writer.Write("Number of products: ");
            customerDetails.Add(this.Reader.ReadLine());

            return customerDetails;
        }

        private void DrawDetailsView()
        {
            this.Writer.Write(Constants.TopLeftAngle + new string(Constants.HorizontalLine, Console.BufferWidth - 2) + Constants.TopRightAngle);
            this.Cursor.SetCursorPosition(0, Console.BufferHeight - 2);
            this.Writer.Write(Constants.BottomLeftAngle + new string(Constants.HorizontalLine, Console.BufferWidth - 2) + Constants.BottomRightAngle);
        }

        private void SelectSubCategories(int currentSelection, string actionType)
        {
            if (currentSelection == 1)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c < 200)
                    .Select(sc => sc.ToString())
                    .ToList();

                this.ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 2)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 201 && (int)c < 300)
                    .Select(sc => sc.ToString())
                    .ToList();

                this.ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 3)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 301 && (int)c < 400)
                    .Select(sc => sc.ToString())
                    .ToList();

                this.ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 4)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 401 && (int)c < 500)
                    .Select(sc => sc.ToString())
                    .ToList();

                this.ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 5)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 501 && (int)c < 600)
                    .Select(sc => sc.ToString())
                    .ToList();

                this.ShowMenu(subCategories, actionType, currentSelection);
            }
        }

        private void PrintHeadLine(string category, string subCategory)
        {
            this.Cursor.Clear();
            this.Color.ForegroundColor(ConsoleColor.Yellow);
            StringBuilder sb = new StringBuilder();
            sb.Append(new string(Constants.HorizontalLine, 23))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, category.ToString().Length))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, 11))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, subCategory.ToString().Length + 2));

            string headLine = $"Add product to Category{Constants.VerticalLine}{category}{Constants.VerticalLine}SubCategory{Constants.VerticalLine} {subCategory}";
            this.Writer.WriteLine(headLine);
            this.Writer.WriteLine(sb.ToString());
        }

        private void ConsoleSize()
        {
            Console.WindowHeight = 25;
            Console.BufferHeight = 25;
            Console.WindowWidth = 70;
            Console.BufferWidth = 70;
        }
    }
}
