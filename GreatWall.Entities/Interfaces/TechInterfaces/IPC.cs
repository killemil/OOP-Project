namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IPC
    {
        string Motherboard { get; }

        string Processor { get; }

        string OperationalMemory { get; }

        string GraphicCard { get; }

        string InternalMemory { get; }

        string OpticalDrive { get; }

        string OperationalSystem { get; }

        string PowerSupply { get; }
    }
}
