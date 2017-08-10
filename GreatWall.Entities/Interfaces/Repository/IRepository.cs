namespace GreatWall.Entities.Interfaces.Repository
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.Customers;
    using System.Collections.Generic;

    public interface IRepository
    {
        void AddProduct(Category category, SubCategory subCategory, IList<string> productData);

        void RemoveProduct(IProduct product, int quantity);

        IList<IProduct> GetProductData(SubCategory subcategory);

        void AddClient(IList<string> customerDetails, IProduct currentProduct);

        IList<ICustomer> GetAllCustomers();
    }
}
