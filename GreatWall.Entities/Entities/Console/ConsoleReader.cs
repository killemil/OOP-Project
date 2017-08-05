namespace GreatWall.Entities.Entities.Console
{
    using System;
    using GreatWall.Entities.Interfaces.Console;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
