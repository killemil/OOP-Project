namespace GreatWall.Entities.Interfaces.Console
{
    using System;

    public interface IColor
    {
        void ForegroundColor(ConsoleColor color);

        void BackgroundColor(ConsoleColor color);
    }
}
