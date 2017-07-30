namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IHardDrive : IProduct
    {
        string HardDriveType { get; }

        string HardDriveCapacity { get; }

        string HardDriveInterface { get; }

        double HardDriveWriteSpeed { get; }

        double HardDriveReadSpeed { get; }
    }
}
