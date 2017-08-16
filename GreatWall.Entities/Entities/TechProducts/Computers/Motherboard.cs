namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Motherboard : Product, IMotherboard
    {
        private string cpuSocket;
        private string videoSlot;
        private int maxRamCapacity;

        public Motherboard(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string cpuSocket, string videoSlot, int maxRamCapacity)
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.CPUSocket)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.VideoSlot)} is required!");
                }

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
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.MaxRamCapacity));
                }

                this.maxRamCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"CPU Socket: {this.CPUSocket}");
            sb.AppendLine($"Video Slot: {this.VideoSlot}");
            sb.AppendLine($"Max Ram Capacity: {this.MaxRamCapacity} MB");

            return sb.ToString();
        }
    }
}
