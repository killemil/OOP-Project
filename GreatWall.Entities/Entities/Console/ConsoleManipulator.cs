namespace GreatWall.Entities.Entities.Console
{
    using System;
    using GreatWall.Entities.Interfaces.Console;

    public class ConsoleManipulator : IConsoleManipulator
    {
        public void BackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public void ForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void CursorLeft(int left)
        {
            Console.CursorLeft = left;
        }

        public void CursorTop(int top)
        {
            Console.CursorTop = top;
        }

        public void CursorVisible(bool condition)
        {
            Console.CursorVisible = condition;
        }

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }
    }
}
