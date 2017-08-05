namespace GreatWall.Entities.Interfaces.Customers
{
    using System.Collections.Generic;

    public interface ICustomer
    {
        string Name { get; }

        string Address { get; }

        string TelephoneNumber { get; }

        IDictionary<IProduct,int> Products { get; }

        void AddProduct(IProduct product, int quantity);
    }
}
