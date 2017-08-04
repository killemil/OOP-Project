namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IPhone : IProduct
    {
        string SimCardType { get; }

        string MemorySlot { get; }

        string NetworkCompatibility { get; }
        
        int BatteryCapacity { get; }
    }
}
