
namespace GreatWall.Client.Core
{
    using System;

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

            int pageSize = 4;
            int pointer = 1;
            while (true)
            {

                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();

                int current = 1;
                Console.CursorTop = 10;
                foreach (var item in menuItems)
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
                        //ShowOtherMenu(pointer);
                        break;
                    case ConsoleKey.UpArrow:
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (pointer <= 1)
                        {
                            pointer = 4;
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
                        Environment.Exit(0);
                        return;
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
