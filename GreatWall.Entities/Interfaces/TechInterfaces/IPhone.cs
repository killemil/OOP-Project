namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IPhone : IProduct
    {
        string SimCardType { get; }

        string PhoneMemorySlot { get; }

        string NetworkCompatibility { get; }
    }
}
