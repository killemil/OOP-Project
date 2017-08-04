﻿namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Motherboard : Product, IMotherboard
    {
        private string cpuSocket;
        private string videoSlot;
        private int maxRamCapacity;

        public Motherboard(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string cpuSocket, string videoSlot, int maxRamCapacity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.CPUSocket = cpuSocket;
            this.VideoSlot = videoSlot;
            this.MaxRamCapacity = maxRamCapacity;
        }

        public string CPUSocket
        {
            get
            {
                return this.cpuSocket;
            }
            private set
            {
                this.cpuSocket = value;
            }
        }
        public string VideoSlot
        {
            get
            {
                return this.videoSlot;
            }
            private set
            {
                this.videoSlot = value;
            }
        }

        public int MaxRamCapacity
        {
            get
            {
                return this.maxRamCapacity;
            }
            private set
            {
                this.maxRamCapacity = value;
            }
        }
    }
}