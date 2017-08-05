namespace GreatWall.Entities.Entities.Console
{
    using System;
    using GreatWall.Entities.Interfaces.Console;

    public class ConsoleColour : IColor
    {
        public void BackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public void ForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
