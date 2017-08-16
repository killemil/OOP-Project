namespace GreatWall.Entities.Interfaces
{
    using GreatWall.Entities.Enumerations;

    public interface IProduct
    {
        string Model { get; }

        string Manufacturer { get; }

        int Quantity { get; set; }

        decimal Price { get; }

        string Color { get; }

        double Weight { get; }

        string Size { get; }

        Category Category { get; }

        SubCategory SubCategory { get; }
    }
}
