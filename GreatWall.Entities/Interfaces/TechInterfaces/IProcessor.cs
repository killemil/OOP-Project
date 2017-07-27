namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IProcessor : IProduct
    {
        string Capacity { get; }

        int Cores { get; }
    }
}
