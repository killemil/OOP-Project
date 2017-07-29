
namespace GreatWall.Client.Core
{
    using GreatWall.Entities.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private string[] menuItems;

        public Engine()
        {
            this.menuItems = new string[]
            {
                "Add Product",
                "Buy Product",
                "About",
                "Exit"
            };
        }

        public void Run()
        {
            this.ConsoleSize();
            ShowMenu(this.menuItems, "mainMenu");
        }

        private void ShowMenu(IList<string> list, string menu)
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
                        ShowOtherMenu(pointer, menu);
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

        private void ShowOtherMenu(int currentSelection, string menu)
        {
            if (menu == "mainMenu")
            {
                if (currentSelection == 1)
                {
                    var categories = Enum.GetValues(typeof(Category))
                                        .OfType<Category>()
                                        .Select(c => c.ToString())
                                        .ToList();

                    ShowMenu(categories, "subCategory");
                }
            }
            else if (menu == "subCategory")
            {
                if (currentSelection == 1)
                {
                    var subCategories = Enum.GetValues(typeof(ComputerSubCategory))
                        .OfType<ComputerSubCategory>()
                        .Select(sc => sc.ToString())
                        .ToList();

                    ShowMenu(subCategories, "addProduct");
                }
                else if(currentSelection == 2)
                {
                    var subCategories = Enum.GetValues(typeof(TVSubCategory))
                        .OfType<TVSubCategory>()
                        .Select(sc => sc.ToString())
                        .ToList();

                    ShowMenu(subCategories, "addProduct");
                }
                else if (currentSelection == 3)
                {
                    var subCategories = Enum.GetValues(typeof(CameraSubCategory))
                        .OfType<CameraSubCategory>()
                        .Select(sc => sc.ToString())
                        .ToList();

                    ShowMenu(subCategories, "addProduct");
                }
                else if (currentSelection == 4)
                {
                    var subCategories = Enum.GetValues(typeof(PhoneSubCategory))
                        .OfType<PhoneSubCategory>()
                        .Select(sc => sc.ToString())
                        .ToList();

                    ShowMenu(subCategories, "addProduct");
                }
            }
        }

        private void ConsoleSize()
        {
            Console.WindowHeight = 25;
            Console.BufferHeight = 25;
            Console.WindowWidth = 55;
            Console.BufferWidth = 55;
        }
    }
}
