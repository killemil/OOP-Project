﻿namespace GreatWall.Entities.Interfaces.TechInterfaces
{
    public interface IGraphicCard : IProduct
    {
        string VideoCardSlot { get; }

        string VideoCardModel { get; }
        
        string MemoryType { get; }

        string MemoryCapacity { get; }
    }
}