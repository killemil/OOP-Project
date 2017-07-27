namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IDisplay : IProduct
    {
        string DisplayType { get; }

        bool TouchScreen { get; }

        string DisplayResolution { get; }

        string DisplaySizeInInches { get; }

        string DisplayColors { get; }
    }
}
