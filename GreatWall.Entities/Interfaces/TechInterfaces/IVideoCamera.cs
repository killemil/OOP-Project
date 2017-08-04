namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IVideoCamera
    {
        string BatteryType { get; }

        string BatteryCapacity { get; }

        string MemoryType { get; }

        string MemorySpeed { get; }

        string MemoryCapacity { get; }

        string LensDesign { get; }

        string LensManufacturer { get; }
    }
}
