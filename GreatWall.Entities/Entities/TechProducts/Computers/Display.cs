namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Display : Product, IDisplay
    {
        private string displayType;
        private bool hasTouchScreen;
        private string displayResolution;
        private string displaySizeInInches;
        private string colors;

        public Display(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string displayType, bool hasTouchScreen, string displayResolution, string displaySizeInInches, string colors)
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.DisplayType)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.DisplayResolution)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.DisplaySizeInInches)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Colors)} is required!");
                }

                this.colors = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Display Type: {this.DisplayType}");
            sb.AppendLine($"Touch Screen {(this.HasTouchScreen == true ? "Yes" : "No")}");
            sb.AppendLine($"Display Resolution: {this.DisplayResolution}");
            sb.AppendLine($"Display Size(Inches): {this.DisplaySizeInInches}");
            sb.AppendLine($"Colors: {this.Color}");

            return sb.ToString();
        }
    }
}