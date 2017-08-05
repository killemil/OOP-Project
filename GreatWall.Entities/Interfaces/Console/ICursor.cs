namespace GreatWall.Entities.Interfaces.Console
{
    public interface ICursor
    {
        void SetCursorPosition(int left, int top);

        void Clear();

        void CursorTop(int top);

        void CursorLeft(int left);

        void CursorVisible(bool condition);
    }
}
