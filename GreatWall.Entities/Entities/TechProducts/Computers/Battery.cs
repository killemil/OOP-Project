namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Battery : Product, IBattery
    {
        private string batteryType;
        private string batteryCapacity;

        public Battery(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string batteryType, string batteryCapacity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.BatteryType = batteryType;
            this.BatteryCapacity = batteryCapacity;
        }

        public string BatteryType
        {
            get
            {
                return this.batteryType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.BatteryType)} is required!");
                }

                this.batteryType = value;
            }
        }

        public string BatteryCapacity
        {
            get
            {
                return this.batteryCapacity;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.BatteryCapacity)} is required!");
                }

                this.batteryCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Battery Type: {this.BatteryType}");
            sb.AppendLine($"Battery Capacity: {this.BatteryCapacity}");

            return sb.ToString();
        }
    }
}
