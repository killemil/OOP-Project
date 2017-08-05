namespace GreatWall.Entities.Entities.TechProducts.TVs
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System.Text;

    public class SmartTV : Product, ISmartTv
    {
        private bool has3DFunction;
        private string operationalSystem;
        private string displayType;
        private string sizeInInches;
        private string resolution;
        private int powerConsumption;

        public SmartTV(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            bool has3DFunction, string operationalSystem, string displayType, string sizeInInches, string resolution, int powerConsumption)
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
