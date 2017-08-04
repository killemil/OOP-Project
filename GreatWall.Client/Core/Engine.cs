namespace GreatWall.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using GreatWall.Client.Factory;
    using GreatWall.Client.SeedData;
    using GreatWall.Client.StaticData;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;

    public class Engine
    {
        private string browseOrAdd;
        private string[] menuItems;
        private IList<IProduct> products;

        public Engine()
        {
            this.menuItems = new string[]
            {
                "Add Product",
                "Browse Products",
                "About",
                "Exit"
            };
            this.products = new List<IProduct>(Seed.SeedData());
        }

        public void Run()
        {
            this.ConsoleSize();
            ShowMenu(this.menuItems, "mainMenu");
        }

        private void ShowMenu(IList<string> list, string menu, params int[] categoryNumber)
        {
            int pageSize = list.Count;
            int pointer = 1;

            while (true)
            {
                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.Write(Constants.Logo);
                Console.CursorTop = 8;
                Console.CursorLeft = 10;
                if (menu == "mainMenu") Console.WriteLine("MAIN MENU");
                else if (menu == "subCategory") Console.WriteLine("CATEGORIES:");
                else if (menu == "addProduct" || menu == "browse") Console.WriteLine("SUBCATEGORIES:");

                int current = 1;
                Console.CursorTop = 10;
                foreach (var item in list)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    current++;
                    Console.CursorLeft = 10;
                    Console.WriteLine(item);
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        ShowOtherMenu(pointer, menu, categoryNumber);
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
                        ShowMenu(this.menuItems, "mainMenu");
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

                    ShowMenu(categories, "subCategory", currentSelection);
                }
                else if (currentSelection == 4)
                {
                    Environment.Exit(0);
                }
            }
            else if (menu == "subCategory")
            {
                SelectSubCategories(currentSelection, this.browseOrAdd);
            }
            else if (menu == "addProduct")
            {
                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                AddProduct(category, subCategory);
            }
            else if (menu == "browse")
            {
                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Category category = (Category)(categoryNumber[0] * 100);
                SubCategory subCategory = (SubCategory)(currentSelection + (int)category);

                BrowseProducts(category, subCategory);
            }
        }

        private void BrowseProducts(Category category, SubCategory subCategory)
        {
            int pageSize = 7;
            int currentPage = 0;
            int maxPages = (int)Math.Ceiling(this.products.Where(p=> p.SubCategory == subCategory).Count() / (double)pageSize);
            int pointer = 1;

            Console.WriteLine($"Products in Category: {category.ToString()}, SubCategory: {subCategory.ToString()}");
            StringBuilder sb = new StringBuilder();
            string horizontalLine = new string(Constants.HorizontalLine, 10);
            sb.Append(horizontalLine)
                .Append(Constants.CrossSign)
                .Append(horizontalLine + new string(Constants.HorizontalLine,2))
                .Append(Constants.CrossSign)
                .Append(horizontalLine)
                .Append(Constants.CrossSign)
                .Append(horizontalLine)
                .Append(Constants.CrossSign);

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine($" Model    {Constants.VerticalLine}Manufacturer{Constants.VerticalLine} Price    {Constants.VerticalLine} Quantity {Constants.VerticalLine} (Page {currentPage + 1} of {maxPages})");
                Console.WriteLine(sb);
                bool hasProductsInCategory = false;
                int current = 1;

                foreach (var product in this.products
                                            .Where(p => p.SubCategory == subCategory)
                                            .Skip(pageSize * currentPage)
                                            .Take(pageSize))
                {

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{(product.Model.Length > 10 ? product.Model.Substring(0, 10) : product.Model),10 }{Constants.VerticalLine}{product.Manufacturer,12}{Constants.VerticalLine}{product.Price,10}{Constants.VerticalLine}{product.Quantity,10}{Constants.VerticalLine}");
                    hasProductsInCategory = true;
                    current++;
                }

                if (!hasProductsInCategory)
                {
                    Console.WriteLine(Constants.NoProductInCategory);
                    Console.WriteLine(Constants.PreeAnyKeyToContinue);
                    Console.ReadKey();
                    Run();
                }

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        IProduct currentProduct = this.products
                            .Where(p => p.Category == category && p.SubCategory == subCategory)
                            .Skip(pageSize * currentPage + pointer - 1)
                            .FirstOrDefault();
                        ShowDetails(currentProduct);
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
                        Run();
                        break;
                }
            }
        }

        private void ShowDetails(IProduct currentProduct)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine(currentProduct);

            Console.ReadKey();
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

                ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 2)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 201 && (int)c < 300)
                    .Select(sc => sc.ToString())
                    .ToList();

                ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 3)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 301 && (int)c < 400)
                    .Select(sc => sc.ToString())
                    .ToList();

                ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 4)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 401 && (int)c < 500)
                    .Select(sc => sc.ToString())
                    .ToList();

                ShowMenu(subCategories, actionType, currentSelection);
            }
            else if (currentSelection == 5)
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Where(c => (int)c >= 501 && (int)c < 600)
                    .Select(sc => sc.ToString())
                    .ToList();

                ShowMenu(subCategories, actionType, currentSelection);
            }
        }

        private void AddProduct(Category category, SubCategory subCategory)
        {
            string categoryStr = category.ToString();
            string subCategoryStr = subCategory.ToString();

            PrintHeadLine(categoryStr, subCategoryStr);
            IList<string> productData = GetProductData(categoryStr, subCategoryStr);
            this.products.Add(ProductFactory.GetProduct(category, subCategory, productData));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(Constants.SuccesfullyAddedProduct);
            Console.WriteLine(Constants.PreeAnyKeyToContinue);
            Console.ReadKey();

            this.Run();
        }

        private IList<string> GetProductData(string categoryStr, string subCategoryStr)
        {
            string className = subCategoryStr.Substring(0, subCategoryStr.Length - 1);
            Type element = Type.GetType(Constants.ClassesNamespace + categoryStr + "." + className + Constants.AssemblyName);
            PropertyInfo[] baseProperties = element.BaseType.GetProperties();
            PropertyInfo[] currentClassProperties = element.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            IList<string> productData = new List<string>();
            for (int i = 0; i < baseProperties.Length - 2; i++)
            {
                string propertyType = baseProperties[i].PropertyType.Name;
                Console.Write(baseProperties[i].Name + $"({propertyType})" + ": ");
                string productInfo = Console.ReadLine();
                productData.Add(productInfo);
                Console.WriteLine(new string(Constants.HorizontalLine, baseProperties[i].Name.Length + propertyType.Length + productInfo.Length + 4) + Constants.EndChar);
            }
            for (int i = 0; i < currentClassProperties.Length; i++)
            {
                string propertyType = currentClassProperties[i].PropertyType.Name;
                Console.Write(currentClassProperties[i].Name + $"({propertyType})" + ": ");
                string productInfo = Console.ReadLine();
                productData.Add(productInfo);
                Console.WriteLine(new string(Constants.HorizontalLine, currentClassProperties[i].Name.Length + propertyType.Length + productInfo.Length + 4) + Constants.EndChar);
            }

            return productData;
        }

        private static void PrintHeadLine(string category, string subCategory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            StringBuilder sb = new StringBuilder();
            sb.Append(new string(Constants.HorizontalLine, 23))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, category.ToString().Length))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, 11))
                .Append(Constants.TSymbol)
                .Append(new string(Constants.HorizontalLine, subCategory.ToString().Length + 2));

            Console.WriteLine($"Add product to Category{Constants.VerticalLine}{category}{Constants.VerticalLine}SubCategory{Constants.VerticalLine} {subCategory}");
            Console.WriteLine(sb);
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
