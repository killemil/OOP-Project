namespace GreatWall.Entities.Entities.TechProducts.TVs
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class TV : Product, ITv
    {
        private string displayType;
        private string sizeInInches;
        private string resolution;
        private int powerConsumption;

        public TV(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string displayType, string sizeInInches, string resolution, int powerConsumption)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.DisplayType = displayType;
            this.SizeInIncehs = sizeInInches;
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
                this.displayType = value;
            }
        }

        public string SizeInIncehs
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
    }
}

