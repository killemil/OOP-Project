namespace GreatWall.Entities.Interfaces.Console
{
    using System;

    public interface IConsoleManipulator
    {
        void ForegroundColor(ConsoleColor color);

        void BackgroundColor(ConsoleColor color);

        void SetCursorPosition(int left, int top);

        void Clear();

        void CursorTop(int top);

        void CursorLeft(int left);

        void CursorVisible(bool condition);
    }
}
