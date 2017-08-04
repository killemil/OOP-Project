namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IHeadphone : IAudio
    {
        bool HasCable { get; }

        int SignalFrequency { get; }

        double Diameter { get; }
    }
}
