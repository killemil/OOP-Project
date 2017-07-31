namespace GreatWall.Entities.Entities.TechProducts.Tv
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;

    public class Tv : Product
    {
        public Tv(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
        }
    }
}
