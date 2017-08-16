namespace GreatWall.Entities.Entities.TechProducts.Phones
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Phone : Product, IPhone
    {
        private string simCardType;
        private string memorySlot;
        private string networkCompatibility;
        private int batteryCapacity;

        public Phone(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string simCardType, string memorySlot, string networkCompatibility, int batteryCapacity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.SimCardType = simCardType;
            this.MemorySlot = memorySlot;
            this.NetworkCompatibility = networkCompatibility;
            this.BatteryCapacity = batteryCapacity;
        }

        public string SimCardType
        {
            get
            {
                return this.simCardType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.SimCardType)} is required!");
                }

                this.simCardType = value;
            }
        }

        public string MemorySlot
        {
            get
            {
                return this.memorySlot;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.MemorySlot)} is required!");
                }

                this.memorySlot = value;
            }
        }

        public string NetworkCompatibility
        {
            get
            {
                return this.networkCompatibility;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.NetworkCompatibility)} is required!");
                }

                this.networkCompatibility = value;
            }
        }

        public int BatteryCapacity
        {
            get
            {
                return this.batteryCapacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.batteryCapacity));
                }

                this.batteryCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Sim Card Type: {this.SimCardType}");
            sb.AppendLine($"Memory Slot: {this.MemorySlot}");
            sb.AppendLine($"Network Compatibility: {this.NetworkCompatibility}");
            sb.AppendLine($"Battery Capacity: {this.BatteryCapacity}");

            return sb.ToString();
        }
    }
}
