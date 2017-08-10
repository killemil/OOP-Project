namespace GreatWall.Entities.Exceptions
{
    using System;

    public class NotEnoughProductsException : Exception
    {
        private const string NotEnoughProducts = "There isn't enough pieces of this product!";

        public NotEnoughProductsException()
            : base(NotEnoughProducts)
        {
        }

        public NotEnoughProductsException(string message)
            : base(message)
        {
        }
    }
}
