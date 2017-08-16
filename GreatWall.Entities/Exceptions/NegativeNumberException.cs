namespace GreatWall.Entities.Exceptions
{
    using System;

    public class NegativeNumberException : Exception
    {
        private const string Message = "can not be negative number!";

        public NegativeNumberException(string message)
            : base(message + " " + Message)
        {
        }
    }
}
