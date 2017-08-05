namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System.Text;

    public class Battery : Product, IBattery
    {
        private string batteryType;
        private string batteryCapacity;

        public Battery(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string batteryType, string batteryCapacity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.BatteryType = batteryType;
            this.BatteryCapacity = batteryCapacity;
        }

        public string BatteryType
        {
            get { return this.batteryType; }
            private set { this.batteryType = value; }
        }
        public string BatteryCapacity
        {
            get { return this.batteryCapacity; }
            private set { this.batteryCapacity = value; }
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
