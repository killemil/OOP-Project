namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IGraphicCard : IProduct
    {
        string SlotType { get; }
        
        string MemoryType { get; }

        string MemoryCapacity { get; }
    }
}
