namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Display : Product, IDisplay
    {
        private string displayType;
        private bool hasTouchScreen;
        private string displayResolution;
        private string displaySizeInInches;
        private string colors;

        public Display(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string displayType, bool hasTouchScreen, string displayResolution, string displaySizeInInches, string colors)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.DisplayType = displayType;
            this.HasTouchScreen = hasTouchScreen;
            this.DisplayResolution = displayResolution;
            this.DisplaySizeInInches = displaySizeInInches;
            this.Colors = colors;
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

        public bool HasTouchScreen
        {
            get
            {
                return this.hasTouchScreen;
            }
            private set
            {
                this.hasTouchScreen = value;
            }
        }

        public string DisplayResolution
        {
            get
            {
                return this.displayResolution;
            }
            private set
            {
                this.displayResolution = value;
            }
        }

        public string DisplaySizeInInches
        {
            get
            {
                return this.displaySizeInInches;
            }
            private set
            {
                this.displaySizeInInches = value;
            }
        }

        public string Colors
        {
            get
            {
                return this.colors;
            }
            private set
            {
                this.colors = value;
            }
        }
    }
}
