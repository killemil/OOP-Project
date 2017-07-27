namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IMemory : IProduct
    {
        string MemoryType { get; }

        string MemorySpeed { get; }

        string MemoryCapacity { get; }
    }
}
