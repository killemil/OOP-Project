namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Speaker : Product, ISpeaker
    {
        private int power;
        private string type;
        private int sensitivity;

        public Speaker(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, Category category, SubCategory subCategory, int power, string type, int sensitivity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Power = power;
            this.type = type;
            this.Sensitivity = sensitivity;
        }

        public int Sensitivity
        {
            get
            {
                return this.sensitivity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.Sensitivity));
                }

                this.sensitivity = value;
            }
        }

        public int Power
        {
            get
            {
                return this.power;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.Power));
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Type)} is required!");
                }

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
