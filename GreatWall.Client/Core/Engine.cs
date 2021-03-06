﻿namespace GreatWall.Client.Core
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
    using GreatWall.Entities.Interfaces.Engine;
    using GreatWall.Entities.Interfaces.Repository;

    public class Engine : IEngine
    {
        private string browseOrAdd;
        private string[] menuItems;
        private IRepository productRepository;
        private ICollector dataCollector;
        private IWriter writer;
        private IConsoleManipulator consoleManipulator;

        public Engine(IRepository productRepository, ICollector dataCollector, IWriter writer, IConsoleManipulator consoleManupulator)
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
            this.dataCollector = dataCollector;
            this.consoleManipulator = consoleManupulator;
        }

        public void Run()
        {
            this.SetConsoleSize();
            try
            {
                this.PrintMenuOptions(this.menuItems, Constants.MainMenuLabel);
            }
            catch (Exception e)
            {
                this.consoleManipulator.ForegroundColor(ConsoleColor.Red);
                this.writer.WriteLine(e.Message);
                Console.ReadKey();
                this.Run();
            }
        }

        private void PrintMenuOptions(IList<string> list, string menu, params int[] categoryNumber)
        {
            int pageSize = list.Count;
            int pointer = 1;

            while (true)
            {
                this.consoleManipulator.CursorVisible(false);
                this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);

                this.consoleManipulator.Clear();
                this.consoleManipulator.SetCursorPosition(0, 0);
                this.writer.Write(Constants.Logo);
                this.consoleManipulator.CursorTop(8);
                this.consoleManipulator.CursorLeft(10);

                if (menu == Constants.MainMenuLabel) this.writer.WriteLine(Constants.MainMenuLabel.ToUpper());
                else if (menu == Constants.SubCategoryLabel) this.writer.WriteLine("CATEGORIES:");
                else if (menu == Constants.AddProductLabel || menu == Constants.BrowseLabel) this.writer.WriteLine("SUBCATEGORIES:");

                int current = 1;
                this.consoleManipulator.CursorTop(10);
                foreach (var item in list)
                {
                    this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                    this.consoleManipulator.ForegroundColor(ConsoleColor.White);
                    if (current == pointer)
                    {
                        this.consoleManipulator.BackgroundColor(ConsoleColor.White);
                        this.consoleManipulator.ForegroundColor(ConsoleColor.Black);
                    }

                    current++;
                    this.consoleManipulator.CursorLeft(10);
                    this.writer.WriteLine(item);
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        this.PrintSubMenu(pointer, menu, categoryNumber);
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
                        this.PrintMenuOptions(this.menuItems, Constants.MainMenuLabel);
                        break;
                }
            }
        }

        private void PrintSubMenu(int currentSelection, string menu, params int[] categoryNumber)
        {
            if (menu == Constants.MainMenuLabel)
            {
                if (currentSelection == 1 || currentSelection == 2)
                {
                    this.browseOrAdd = currentSelection == 1 ? Constants.AddProductLabel : Constants.BrowseLabel;
                    string[] categories = Enum.GetNames(typeof(Category));
                    this.LoginForAddingProduct();
                    this.PrintMenuOptions(categories, Constants.SubCategoryLabel, currentSelection);
                }
                else if (currentSelection == 3)
                {
                    this.PrintSaleHistory();
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
                this.consoleManipulator.CursorVisible(false);
                this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                this.consoleManipulator.ForegroundColor(ConsoleColor.White);
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                string categoryStr = category.ToString();
                string subCategoryStr = subCategory.ToString();
                this.PrintHeadLine(categoryStr, subCategoryStr);
                IList<string> productData = this.dataCollector.GetProductDetails(categoryStr, subCategoryStr);
                this.productRepository.AddProduct(category, subCategory, productData);

                this.consoleManipulator.ForegroundColor(ConsoleColor.Green);
                this.writer.WriteLine(Constants.SuccesfullyAddedProduct);
                this.writer.WriteLine(Constants.PreeAnyKeyToContinue);
                Console.ReadKey();

                this.Run();
            }
            else if (menu == Constants.BrowseLabel)
            {
                this.consoleManipulator.CursorVisible(false);
                this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                this.consoleManipulator.ForegroundColor(ConsoleColor.White);
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                this.PrintBrowseProductsMenu(category, subCategory);
            }
        }

        private void PrintSaleHistory()
        {
            IList<ICustomer> sales = this.productRepository.GetAllCustomers();

            int pageSize = 15;
            int currentPage = 0;
            int maxPages = (int)Math.Ceiling(sales.Count() / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
                this.consoleManipulator.Clear();
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
                    this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                    this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.consoleManipulator.BackgroundColor(ConsoleColor.Yellow);
                        this.consoleManipulator.ForegroundColor(ConsoleColor.Black);
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
                        this.PrintSaleDetails(currentSale);
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

        private void PrintSaleDetails(ICustomer currentSale)
        {
            this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
            this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
            this.consoleManipulator.Clear();
            this.PrintDetailsGrid();
            this.consoleManipulator.SetCursorPosition(0, 1);
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
                    this.consoleManipulator.ForegroundColor(ConsoleColor.Red);
                    throw new InvalidUsernamerOrPasswordException();
                }

                this.consoleManipulator.ForegroundColor(ConsoleColor.Green);
                this.writer.Write(Constants.SuccessLogin);
                Console.ReadKey();
            }
        }

        private void PrintBrowseProductsMenu(Category category, SubCategory subCategory)
        {
            IList<IProduct> products = this.productRepository.GetProductsBySubCategory(subCategory);

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
                this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
                this.consoleManipulator.Clear();
                this.writer.WriteLine($" Model    {Constants.VerticalLine}Manufacturer{Constants.VerticalLine} Price    {Constants.VerticalLine} Quantity {Constants.VerticalLine} (Page {currentPage + 1} of {maxPages})");
                this.writer.WriteLine(sb.ToString());
                bool hasProductsInCategory = false;
                int current = 1;

                foreach (var product in products
                                            .Skip(pageSize * currentPage)
                                            .Take(pageSize))
                {
                    this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                    this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.consoleManipulator.BackgroundColor(ConsoleColor.Yellow);
                        this.consoleManipulator.ForegroundColor(ConsoleColor.Black);
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
                        this.PrintProductDetails(currentProduct);
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

        private void PrintProductDetails(IProduct currentProduct)
        {
            this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
            this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
            this.consoleManipulator.Clear();
            this.PrintDetailsGrid();
            this.consoleManipulator.SetCursorPosition(0, 1);
            this.writer.WriteLine(currentProduct.ToString());

            this.PrintProductDetailsMenu(currentProduct);
        }

        private void PrintProductDetailsMenu(IProduct currentProduct)
        {
            IList<string> detailsMenu = new List<string>
            {
                "Buy product",
                "Back"
            };
            int pointer = 1;
            while (true)
            {
                this.consoleManipulator.SetCursorPosition(5, 20);
                int current = 1;
                foreach (var menuItem in detailsMenu)
                {
                    this.consoleManipulator.BackgroundColor(ConsoleColor.Black);
                    this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
                    if (current == pointer)
                    {
                        this.consoleManipulator.BackgroundColor(ConsoleColor.Yellow);
                        this.consoleManipulator.ForegroundColor(ConsoleColor.Black);
                    }

                    current++;
                    this.consoleManipulator.CursorLeft(5);
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
                            this.consoleManipulator.Clear();
                            this.PrintDetailsGrid();
                            this.consoleManipulator.CursorTop(1);
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
            this.consoleManipulator.ForegroundColor(ConsoleColor.Green);
            this.writer.WriteLine(Constants.SuccessfullyPlacedOrder);
            Console.ReadKey();

            this.Run();
        }

        private void PrintDetailsGrid()
        {
            this.writer.Write(Constants.TopLeftAngle + new string(Constants.HorizontalLine, (Console.BufferWidth / 2) - 4) + "Details" + new string(Constants.HorizontalLine, (Console.BufferWidth / 2) - 5) + Constants.TopRightAngle);
            this.consoleManipulator.SetCursorPosition(0, Console.BufferHeight - 2);
            this.writer.Write(Constants.BottomLeftAngle + new string(Constants.HorizontalLine, Console.BufferWidth - 2) + Constants.BottomRightAngle);
        }

        private void SelectSubCategories(int currentSelection, string actionType)
        {
            var subCategories = Enum.GetValues(typeof(SubCategory))
                .OfType<SubCategory>()
                .Where(c => (int)c > currentSelection * 100 && (int)c < (currentSelection * 100) + 100)
                .Select(sc => sc.ToString())
                .ToList();

            this.PrintMenuOptions(subCategories, actionType, currentSelection);
        }

        private void PrintHeadLine(string category, string subCategory)
        {
            this.consoleManipulator.Clear();
            this.consoleManipulator.ForegroundColor(ConsoleColor.Yellow);
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

        private void SetConsoleSize()
        {
            Console.WindowHeight = 25;
            Console.BufferHeight = 25;
            Console.WindowWidth = 70;
            Console.BufferWidth = 70;
        }
    }
}