namespace GreatWall.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using GreatWall.Client.SaleLogger;
    using GreatWall.Client.StaticData;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Console;
    using GreatWall.Entities.Interfaces.Customers;
    using GreatWall.Entities.Interfaces.DataCollector;
    using GreatWall.Entities.Interfaces.Repository;

    public class Engine
    {
        private string browseOrAdd;
        private string[] menuItems;
        private IRepository productRepository;
        private ICollector dataCollector;
        private IWriter writer;
        private ICursor cursor;
        private IColor color;

        public Engine(IRepository productRepository, ICollector dataCollector, IWriter writer, IColor color, ICursor cursor)
        {
            this.menuItems = new string[]
            {
                "Add Product",
                "Browse Products",
                "Sales History",
                "About",
                "Exit"
            };
            this.productRepository = productRepository;
            this.writer = writer;
            this.color = color;
            this.cursor = cursor;
            this.dataCollector = dataCollector;
        }

        public void Run()
        {
            this.ConsoleSize();
            try
            {
                this.ShowMenu(this.menuItems, Constants.MainMenuLabel);
            }
            catch (Exception e)
            {
                this.color.ForegroundColor(ConsoleColor.Red);
                this.writer.WriteLine(e.Message);
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
                this.cursor.CursorVisible(false);
                this.color.BackgroundColor(ConsoleColor.Black);
                this.color.ForegroundColor(ConsoleColor.Yellow);

                this.cursor.Clear();
                this.cursor.SetCursorPosition(0, 0);
                this.writer.Write(Constants.Logo);
                this.cursor.CursorTop(8);
                this.cursor.CursorLeft(10);

                if (menu == Constants.MainMenuLabel) this.writer.WriteLine(Constants.MainMenuLabel.ToUpper());
                else if (menu == Constants.SubCategoryLabel) this.writer.WriteLine("CATEGORIES:");
                else if (menu == Constants.AddProductLabel || menu == Constants.BrowseLabel) this.writer.WriteLine("SUBCATEGORIES:");

                int current = 1;
                this.cursor.CursorTop(10);
                foreach (var item in list)
                {
                    this.color.BackgroundColor(ConsoleColor.Black);
                    this.color.ForegroundColor(ConsoleColor.White);
                    if (current == pointer)
                    {
                        this.color.BackgroundColor(ConsoleColor.White);
                        this.color.ForegroundColor(ConsoleColor.Black);
                    }

                    current++;
                    this.cursor.CursorLeft(10);
                    this.writer.WriteLine(item);
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
                        this.ShowMenu(this.menuItems, Constants.MainMenuLabel);
                        break;
                }
            }
        }

        private void ShowOtherMenu(int currentSelection, string menu, params int[] categoryNumber)
        {
            if (menu == Constants.MainMenuLabel)
            {
                if (currentSelection == 1 || currentSelection == 2)
                {
                    this.browseOrAdd = currentSelection == 1 ? Constants.AddProductLabel : Constants.BrowseLabel;
                    string[] categories = Enum.GetNames(typeof(Category));
                    this.LoginForAddingProduct();
                    this.ShowMenu(categories, Constants.SubCategoryLabel, currentSelection);
                }
                else if (currentSelection == 3)
                {
                    this.ShowSaleHistory();
                }
                else if (currentSelection == 5)
                {
                    Environment.Exit(0);
                }
            }
            else if (menu == Constants.SubCategoryLabel)
            {
                this.SelectSubCategories(currentSelection, this.browseOrAdd);
            }
            else if (menu == Constants.AddProductLabel)
            {
                this.cursor.CursorVisible(false);
                this.color.BackgroundColor(ConsoleColor.Black);
                this.color.ForegroundColor(ConsoleColor.White);
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                string categoryStr = category.ToString();
                string subCategoryStr = subCategory.ToString();
                this.PrintHeadLine(categoryStr, subCategoryStr);
                IList<string> productData = this.dataCollector.GetProductData(categoryStr, subCategoryStr);
                this.productRepository.AddProduct(category, subCategory, productData);

                this.color.ForegroundColor(ConsoleColor.Green);
                this.writer.WriteLine(Constants.SuccesfullyAddedProduct);
                this.writer.WriteLine(Constants.PreeAnyKeyToContinue);
                Console.ReadKey();

                this.Run();
            }
            else if (menu == Constants.BrowseLabel)
            {
                this.cursor.CursorVisible(false);
                this.color.BackgroundColor(ConsoleColor.Black);
                this.color.ForegroundColor(ConsoleColor.White);
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                this.BrowseProducts(category, subCategory);
            }
        }

        private void ShowSaleHistory()
        {
            IList<ICustomer> sales = this.productRepository.GetAllCustomers();

            int pageSize = 15;
            int currentPage = 0;
            int maxPages = (int)Math.Ceiling(sales.Count() / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                this.color.BackgroundColor(ConsoleColor.Black);
                this.color.ForegroundColor(ConsoleColor.Yellow);
                this.cursor.Clear();
                this.writer.WriteLine($" Customer     {Constants.VerticalLine}Address             {Constants.VerticalLine}Telephone    {Constants.VerticalLine} (Page {currentPage + 1} of {maxPages})");
                StringBuilder sb = new StringBuilder();
                sb.Append(new string(Constants.HorizontalLine, 14))
                .Append(Constants.CrossSign)
                .Append(new string(Constants.HorizontalLine, 20))
                .Append(Constants.CrossSign)
                .Append(new string(Constants.HorizontalLine, 13))
                .Append(Constants.CrossSign);
                this.writer.WriteLine(sb.ToString());

                int current = 1;

                foreach (var sale in sales.Skip(pageSize * currentPage).Take(pageSize))
                {
                    this.color.BackgroundColor(ConsoleColor.Black);
                    this.color.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.color.BackgroundColor(ConsoleColor.Yellow);
                        this.color.ForegroundColor(ConsoleColor.Black);
                    }

                    this.writer.WriteLine($"{(sale.Name.Length > 13 ? sale.Name.Substring(0, 13) : sale.Name),14 }{Constants.VerticalLine}{(sale.Address.Length > 19 ? sale.Address.Substring(0, 19) : sale.Address),20}{Constants.VerticalLine}{(sale.TelephoneNumber.Length > 12 ? sale.TelephoneNumber.Substring(0, 12) : sale.TelephoneNumber),13}{Constants.VerticalLine}");
                    current++;
                }

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        ICustomer currentSale = sales
                            .Skip((pageSize * currentPage) + pointer - 1)
                            .FirstOrDefault();
                        this.ShowSaleDetails(currentSale);
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

        private void ShowSaleDetails(ICustomer currentSale)
        {
            this.color.BackgroundColor(ConsoleColor.Black);
            this.color.ForegroundColor(ConsoleColor.Yellow);
            this.cursor.Clear();
            this.DrawDetailsView();
            this.cursor.SetCursorPosition(0, 1);
            this.writer.WriteLine(currentSale.ToString());

            Console.ReadKey();
        }

        private void LoginForAddingProduct()
        {
            if (this.browseOrAdd == Constants.AddProductLabel)
            {
                IList<string> usernameAndPasword = new List<string>(this.dataCollector.GetLoginDetails());

                if (usernameAndPasword[0] != Constants.AdminUsername || usernameAndPasword[1] != Constants.AdminPassword)
                {
                    this.color.ForegroundColor(ConsoleColor.Red);
                    throw new InvalidUsernamerOrPasswordException();
                }

                this.color.ForegroundColor(ConsoleColor.Green);
                this.writer.Write(Constants.SuccessLogin);
                Console.ReadKey();
            }
        }

        private void BrowseProducts(Category category, SubCategory subCategory)
        {
            IList<IProduct> products = this.productRepository.GetProductData(subCategory);

            int pageSize = 15;
            int currentPage = 0;
            int maxPages = (int)Math.Ceiling(products.Count() / (double)pageSize);
            int pointer = 1;

            this.writer.WriteLine($"Products in Category: {category.ToString()}, SubCategory: {subCategory.ToString()}");
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
                this.color.BackgroundColor(ConsoleColor.Black);
                this.color.ForegroundColor(ConsoleColor.Yellow);
                this.cursor.Clear();
                this.writer.WriteLine($" Model    {Constants.VerticalLine}Manufacturer{Constants.VerticalLine} Price    {Constants.VerticalLine} Quantity {Constants.VerticalLine} (Page {currentPage + 1} of {maxPages})");
                this.writer.WriteLine(sb.ToString());
                bool hasProductsInCategory = false;
                int current = 1;

                foreach (var product in products
                                            .Skip(pageSize * currentPage)
                                            .Take(pageSize))
                {
                    this.color.BackgroundColor(ConsoleColor.Black);
                    this.color.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.color.BackgroundColor(ConsoleColor.Yellow);
                        this.color.ForegroundColor(ConsoleColor.Black);
                    }

                    this.writer.WriteLine($"{(product.Model.Length > 10 ? product.Model.Substring(0, 10) : product.Model),10 }{Constants.VerticalLine}{product.Manufacturer,12}{Constants.VerticalLine}{product.Price,10}{Constants.VerticalLine}{product.Quantity,10}{Constants.VerticalLine}");
                    hasProductsInCategory = true;
                    current++;
                }

                if (!hasProductsInCategory)
                {
                    this.writer.WriteLine(Constants.NoProductInCategory);
                    this.writer.WriteLine(Constants.PreeAnyKeyToContinue);
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
            this.color.BackgroundColor(ConsoleColor.Black);
            this.color.ForegroundColor(ConsoleColor.Yellow);
            this.cursor.Clear();
            this.DrawDetailsView();
            this.cursor.SetCursorPosition(0, 1);
            this.writer.WriteLine(currentProduct.ToString());

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
                this.cursor.SetCursorPosition(5, 20);
                int current = 1;
                foreach (var menuItem in detailsMenu)
                {
                    this.color.BackgroundColor(ConsoleColor.Black);
                    this.color.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.color.BackgroundColor(ConsoleColor.Yellow);
                        this.color.ForegroundColor(ConsoleColor.Black);
                    }

                    current++;
                    this.cursor.CursorLeft(5);
                    this.writer.WriteLine(menuItem);
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
                            this.cursor.Clear();
                            this.DrawDetailsView();
                            this.cursor.CursorTop(1);
                            IList<string> customerDetails = this.dataCollector.GetCustomerDetails();
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
            this.color.ForegroundColor(ConsoleColor.Green);
            this.writer.WriteLine(Constants.SuccessfullyPlacedOrder);
            Console.ReadKey();

            this.Run();
        }

        private void DrawDetailsView()
        {
            this.writer.Write(Constants.TopLeftAngle + new string(Constants.HorizontalLine, (Console.BufferWidth / 2) - 4) + "Details" + new string(Constants.HorizontalLine, (Console.BufferWidth / 2) - 5) + Constants.TopRightAngle);
            this.cursor.SetCursorPosition(0, Console.BufferHeight - 2);
            this.writer.Write(Constants.BottomLeftAngle + new string(Constants.HorizontalLine, Console.BufferWidth - 2) + Constants.BottomRightAngle);
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
            this.cursor.Clear();
            this.color.ForegroundColor(ConsoleColor.Yellow);
            StringBuilder sb = new StringBuilder();
            sb.Append(new string(Constants.HorizontalLine, 23))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, category.ToString().Length))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, 11))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, subCategory.ToString().Length + 2));

            string headLine = $"Add product to Category{Constants.VerticalLine}{category}{Constants.VerticalLine}SubCategory{Constants.VerticalLine} {subCategory}";
            this.writer.WriteLine(headLine);
            this.writer.WriteLine(sb.ToString());
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