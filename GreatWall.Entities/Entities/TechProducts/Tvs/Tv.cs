namespace GreatWall.Entities.Entities.TechProducts.TVs
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class TV : Product, ITv
    {
        private string displayType;
        private string sizeInInches;
        private string resolution;
        private int powerConsumption;

        public TV(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string displayType, string sizeInInches, string resolution, int powerConsumption)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.DisplayType = displayType;
            this.SizeInInches = sizeInInches;
            this.Resolution = resolution;
            this.PowerConsumption = powerConsumption;
        }

        public string DisplayType
        {
            get
            {
                return this.displayType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.DisplayType)} is required!");
                }

                this.displayType = value;
            }
        }

        public string SizeInInches
        {
            get
            {
                return this.sizeInInches;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.SizeInInches)} is required!");
                }

                this.sizeInInches = value;
            }
        }

        public string Resolution
        {
            get
            {
                return this.resolution;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Resolution)} is required!");
                }

                this.resolution = value;
            }
        }

        public int PowerConsumption
        {
            get
            {
                return this.powerConsumption;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.PowerConsumption));
                }

                this.powerConsumption = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Display Type: {this.DisplayType}");
            sb.AppendLine($"Size(Inches): {this.SizeInInches}");
            sb.AppendLine($"Resolution: {this.Resolution}");
            sb.AppendLine($"Power Consumption(Watts): {this.PowerConsumption}");

            return sb.ToString();
        }
    }
}