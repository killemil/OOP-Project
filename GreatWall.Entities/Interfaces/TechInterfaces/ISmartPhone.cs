namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface ISmartPhone : IPhone
    {
        string Processor { get; }

        string RamMemory { get; }

        string InternalMemory { get; }

        string DisplayType { get; }

        string DisplaySize { get; }

        string OperationalSystem { get; }
    }
}
