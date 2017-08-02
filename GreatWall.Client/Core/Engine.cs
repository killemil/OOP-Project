namespace GreatWall.Client.Core
{
    using GreatWall.Client.Factory;
    using GreatWall.Client.SeedData;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private const char CrossSign = '\u256C';
        private const char VerticalLine = '\u2551';
        private const char HorizontalLine = '\u2550';
        private const char TSymbol = '\u2569';

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
            int maxPages = (int)Math.Ceiling(this.products.Count / (double)pageSize);
            int pointer = 1;

            Console.WriteLine($"Products in Category: {category.ToString()}, SubCategory: {subCategory.ToString()}");
            StringBuilder sb = new StringBuilder();
            string horizontalLine = new string(HorizontalLine, 10);
            sb.Append(horizontalLine)
                .Append(CrossSign)
                .Append(horizontalLine + HorizontalLine + HorizontalLine)
                .Append(CrossSign)
                .Append(horizontalLine)
                .Append(CrossSign)
                .Append(horizontalLine)
                .Append(CrossSign);

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine($" Model    {VerticalLine}Manufacturer{VerticalLine} Price    {VerticalLine} Quantity {VerticalLine} (Page {currentPage + 1} of {maxPages})");
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
                    Console.WriteLine($"{product.Model,10}{VerticalLine}{product.Manufacturer,12}{VerticalLine}{product.Price,10}{VerticalLine}{product.Quantity,10}{VerticalLine}");
                    hasProductsInCategory = true;
                    current++;
                }

                if (!hasProductsInCategory)
                {
                    Console.WriteLine("No products in this category");
                    Console.WriteLine("Press any key to get back to main menu");
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            StringBuilder sb = new StringBuilder();
            sb.Append(new string(HorizontalLine, 23))
                .Append(TSymbol)
                .Append(new string(HorizontalLine, category.ToString().Length))
                .Append(TSymbol)
                .Append(new string(HorizontalLine, 11))
                .Append(TSymbol)
                .Append(new string(HorizontalLine, subCategory.ToString().Length + 2));

            Console.WriteLine($"Add product to Category{VerticalLine}{category.ToString()}{VerticalLine}SubCategory{VerticalLine} {subCategory.ToString()}");
            Console.WriteLine(sb);

            string className = subCategory.ToString().Substring(0, subCategory.ToString().Length - 1);
            Type element = Type.GetType("GreatWall.Entities.Entities.TechProducts." + category.ToString() + "." + className + ", GreatWall.Entities");
            var properties = element.GetProperties();

            IList<string> productData = new List<string>();
            for (int i = 0; i < properties.Length - 2; i++)
            {
                Console.Write(properties[i].Name + ": ");
                string productInfo = Console.ReadLine();
                productData.Add(productInfo);
                Console.WriteLine(new string(HorizontalLine, properties[i].Name.Length + productInfo.Length + 2));
            }

            this.products.Add(ProductFactory.GetProduct(category, subCategory, productData));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Succesfully added a product");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            this.Run();
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
