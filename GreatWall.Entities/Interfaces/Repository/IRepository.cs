namespace GreatWall.Entities.Interfaces.Repository
{
    using System.Collections.Generic;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.Customers;

    public interface IRepository
    {
        void AddProduct(Category category, SubCategory subCategory, IList<string> productData);

        void RemoveProduct(IProduct product, int quantity);

        IList<IProduct> GetProductsBySubCategory(SubCategory subcategory);

        void AddClient(IList<string> customerDetails, IProduct currentProduct);

        IList<ICustomer> GetAllCustomers();
    }
}