namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface ITv
    {
        string DisplayType { get; }

        string SizeInInches { get; }

        string Resolution { get; }

        int PowerConsumption { get; }
    }
}
