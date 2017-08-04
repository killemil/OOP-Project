namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IAmplifier : IAudio
    {
        string Channels { get; }

        bool HasTuner { get; }

        bool HasRemoteControl { get; }
    }
}
