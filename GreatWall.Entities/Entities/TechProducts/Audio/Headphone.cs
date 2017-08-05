namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System.Text;

    public class Headphone : Product, IHeadphone
    {
        private int power;
        private int signalFrequency;
        private bool hasCable;
        private double diameter;

        public Headphone(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, Category category, SubCategory subCategory,
             int power, int signalFrequency, bool hasCable, double diameter)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Power = power;
            this.SignalFrequency = signalFrequency;
            this.HasCable = hasCable;
            this.Diameter = diameter;
        }

        public int SignalFrequency
        {
            get { return this.signalFrequency; }
            private set
            {
                this.signalFrequency = value;
            }
        }

        public int Power
        {
            get { return this.power; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Power cannot be negative number!");
                }
                this.power = value;
            }
        }

        public bool HasCable
        {
            get
            {
                return this.hasCable;
            }
            private set
            {
                this.hasCable = value;
            }
        }

        public double Diameter
        {
            get
            {
                return this.diameter;
            }
            private set
            {
                this.diameter = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Power(Wats): {this.Power}");
            sb.AppendLine($"Signal Frequency: {this.SignalFrequency}");
            sb.AppendLine($"Cordless: {(this.HasCable == true ? "No" : "Yes")}");
            sb.AppendLine($"Diameter: {this.Diameter}");

            return sb.ToString();
        }
    }
}
