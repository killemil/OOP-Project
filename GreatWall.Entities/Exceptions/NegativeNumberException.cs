namespace GreatWall.Entities.Exceptions
{
    using System;

    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message)
            : base(message)
        {
        }
    }
}
