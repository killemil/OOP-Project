namespace GreatWall.Entities.Interfaces
{
    public interface IProduct
    {
        string Model { get; }

        string Manufacturer { get; }

        int Quantity { get; }

        decimal Price { get; }

        string Color { get; }

        double Weight { get; }

        string Size { get; }
    }
}
