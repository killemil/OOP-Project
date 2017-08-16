namespace GreatWall.Entities.Entities.TechProducts.TVs
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class SmartTV : Product, ISmartTv
    {
        private bool has3DFunction;
        private string operationalSystem;
        private string displayType;
        private string sizeInInches;
        private string resolution;
        private int powerConsumption;

        public SmartTV(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, bool has3DFunction, string operationalSystem, string displayType, string sizeInInches, string resolution, int powerConsumption)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Has3DFuncton = has3DFunction;
            this.OperationalSystem = operationalSystem;
            this.DisplayType = displayType;
            this.SizeInInches = sizeInInches;
            this.Resolution = resolution;
            this.PowerConsumption = powerConsumption;
        }

        public bool Has3DFuncton
        {
            get
            {
                return this.has3DFunction;
            }

            private set
            {
                this.has3DFunction = value;
            }
        }

        public string OperationalSystem
        {
            get
            {
                return this.operationalSystem;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.OperationalSystem)} is required!");
                }

                this.operationalSystem = value;
            }
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
            sb.AppendLine($"3D Functon: {(this.Has3DFuncton == true ? "Yes" : "No")}");
            sb.AppendLine($"Operational System: {this.OperationalSystem}");
            sb.AppendLine($"Display Type: {this.DisplayType}");
            sb.AppendLine($"Size(Inches): {this.SizeInInches}");
            sb.AppendLine($"Resolution: {this.Resolution}");
            sb.AppendLine($"Power Consumption(Watts): {this.PowerConsumption}");

            return sb.ToString();
        }
    }
}
