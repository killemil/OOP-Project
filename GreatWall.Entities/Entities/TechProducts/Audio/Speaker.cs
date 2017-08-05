namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using GreatWall.Entities.Enumerations;
    using System;
    using System.Text;

    public class Speaker : Product, ISpeaker
    {
        private int power;
        private string type;
        private int sensitivity;


        public Speaker(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, Category category, SubCategory subCategory,
             int power, string type, int sensitivity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Power = power;
            this.type = type;
            this.Sensitivity = sensitivity;
        }

        public int Sensitivity
        {
            get { return this.sensitivity; }
            set { this.sensitivity = value; }
        }

        public int Power
        {
            get { return this.power; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Power cannot be negative number!");
                }
                this.power = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Power(Wats): {this.Power}");
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Sensitivity(Mhz): {this.Sensitivity}");

            return sb.ToString();
        }
    }
}
