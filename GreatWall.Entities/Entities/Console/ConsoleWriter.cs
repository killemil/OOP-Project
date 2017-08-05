namespace GreatWall.Entities.Entities.Console
{
    using System;
    using GreatWall.Entities.Interfaces.Console;

    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string messase)
        {
            Console.WriteLine(messase);
        }
    }
}
