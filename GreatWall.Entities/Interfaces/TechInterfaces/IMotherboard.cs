namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IMotherboard 
    {
        string CPUSocket { get; }

        string VideoSlot { get; }

        int MaxRamCapacity { get; }
    }
}
