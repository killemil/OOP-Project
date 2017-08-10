namespace GreatWall.Entities.Interfaces.Repository
{
    using GreatWall.Entities.Enumerations;
    using System.Collections.Generic;

    public interface IRepository
    {
        void AddProduct(Category category, SubCategory subCategory);

        void RemoveProduct(IProduct product, int quantity);

        IList<IProduct> GetProductData(SubCategory subcategory);

        void AddClient(IList<string> customerDetails, IProduct currentProduct);
    }
}
