namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface ISpeaker : IAudio
    {
        string Type { get; }

        int Sensitivity { get; }

    }
}
