﻿namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IMemory : IProduct
    {
        string Type { get; }

        string Speed { get; }

        string Capacity { get; }
    }
}
