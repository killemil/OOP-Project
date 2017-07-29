
namespace GreatWall.Client.Core
{
    using GreatWall.Client.Factory;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private string[] menuItems;
        private IList<IProduct> products;
        private string[] initialProductData;

        public Engine()
        {
            this.menuItems = new string[]
            {
                "Add Product",
                "Buy Product",
                "About",
                "Exit"
            };
            this.initialProductData = new string[]
            {
                 "Model: ",
                 "Manufacturer: ",
                 "Quantity: ",
                 "Price: ",
                 "Color: ",
                 "Weight: ",
                 "Size: "
            };
            this.products = new List<IProduct>();
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
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

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

                var key = Console.ReadKey(true);

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
                if (currentSelection == 1)
                {
                    var categories = Enum.GetValues(typeof(Category))
                                        .OfType<Category>()
                                        .Select(c => c.ToString())
                                        .ToList();

                    ShowMenu(categories, "subCategory", currentSelection);
                }
            }
            else if (menu == "subCategory")
            {
                var subCategories = Enum.GetValues(typeof(SubCategory))
                    .OfType<SubCategory>()
                    .Select(sc => sc.ToString())
                    .ToList();


                ShowMenu(subCategories, "addProduct", currentSelection);
            }
            else if (menu == "addProduct")
            {
                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Category category = (Category)categoryNumber[0];
                SubCategory subCategory = (SubCategory)currentSelection;

                AddProduct(category, subCategory);
            }
        }

        private void AddProduct(Category category, SubCategory subCategory)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Add product to Category: {category.ToString()}, SubCategory: {subCategory.ToString()}");
            IList<string> initialData = new List<string>();

            for (int i = 0; i < this.initialProductData.Length; i++)
            {
                Console.Write(this.initialProductData[i]);
                initialData.Add(Console.ReadLine());
            }

            this.products.Add(ProductFactory.GetProduct(category, subCategory, initialData));
            Console.ForegroundColor = ConsoleColor.Cyan;
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
