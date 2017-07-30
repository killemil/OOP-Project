namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IMediaPlayer
    {
        string Type { get; }
        int Capacity { get; }
        string Resolution { get; }
        bool HasRadio { get; }
    }
}
