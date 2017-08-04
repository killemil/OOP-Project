namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface ILaptop 
    {
        string Processor { get; }

        string OperationalMemory { get; }

        string GraphicCard { get; }

        string InternalMemory { get; }

        string DisplaySizeAndResolution { get; }

        string OpticalDrive { get; }

        string Battery { get; }

        string OperationalSystem { get; }
    }
}
