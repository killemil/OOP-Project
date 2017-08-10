namespace GreatWall.Entities.Exceptions
{
    using System;

    public class InvalidUsernamerOrPasswordException : Exception
    {
        private const string InvalidUsernameOrPassword = "Invalid username or password!";

        public InvalidUsernamerOrPasswordException()
            : base(InvalidUsernameOrPassword)
        {
        }

        public InvalidUsernamerOrPasswordException(string message)
            : base(message)
        {
        }
    }
}
