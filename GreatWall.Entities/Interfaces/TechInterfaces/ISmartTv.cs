namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface ISmartTv : ITv
    {
        bool Has3DFuncton { get; }

        string OperationalSystem { get; }
    }
}