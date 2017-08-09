namespace GreatWall.Entities.Interfaces.Repository
{
    using GreatWall.Entities.Enumerations;
    using System.Collections.Generic;

    public interface IProductRepository<T>
    {
        IList<T> Data { get; }

        void Add(Category category, SubCategory subCategory);

        void Remove(T product, int quantity);

        IList<T> GetData(SubCategory subcategory);
    }
}
