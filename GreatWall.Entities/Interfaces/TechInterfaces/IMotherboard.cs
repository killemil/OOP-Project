namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IMotherboard : IProduct
    {
        string CPUSocket { get; }

        string MotherboardChipset { get; }

        string MaxRamCapacity { get; }
    }
}
