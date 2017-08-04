namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IDisplay : IProduct
    {
        string DisplayType { get; }

        bool HasTouchScreen { get; }

        string DisplayResolution { get; }

        string DisplaySizeInInches { get; }

        string Colors { get; }
    }
}
