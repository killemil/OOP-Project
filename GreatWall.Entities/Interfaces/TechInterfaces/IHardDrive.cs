namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IHardDrive : IProduct
    {
        string Type { get; }

        string Capacity { get; }

        string Interface { get; }

        double WriteSpeed { get; }

        double ReadSpeed { get; }
    }
}
