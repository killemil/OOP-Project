namespace GreatWall.Entities.Entities.TechProducts.SmartTv
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class SmartTv : Product, I3DGlasses, IDisplay, IExternalFlashDrive
    {       
        private string displayType;
        private bool touchScreen;
        private string displayResolution;
        private string displaySizeInInches;
        private string displayColors;
        private bool externalFlashDrive;
        private bool glasses3D;

        public SmartTv(string displayType, bool touchScreen, string displayResolution, string displaySizeInInches, string displayColors, 
            bool externalFlashDrive, bool glasses3D, string manufacturer, int quantity, decimal price, string color,
            string model, double weight, string size, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {           
            this.DisplayType = displayType;
            this.TouchScreen = touchScreen;
            this.DisplayResolution = displayResolution;
            this.DisplaySizeInInches = displaySizeInInches;
            this.DisplayColors = displayColors;
            this.ExternalFlashDrive = externalFlashDrive;
            this.Glasses3D = glasses3D;
        }

        public bool Glasses3D
        {
            get{ return this.glasses3D; }
            set { this.glasses3D = value; }
        }

        public string DisplayType
        {
            get { return this.displayType; }
            set { this.displayType = value; }
        }
        public bool TouchScreen
        {
            get { return this.touchScreen; }
            set { this.touchScreen = value; }
        }

        public string DisplayResolution
        {
            get { return this.displayResolution; }
            set { this.displayResolution = value; }
        }

        public string DisplaySizeInInches
        {
            get { return this.displaySizeInInches; }
            set { this.displaySizeInInches = value; }
        }

        public string DisplayColors
        {
            get { return this.displayColors; }
            set { this.displayColors = value; }
        }

        public bool ExternalFlashDrive
        {
            get { return this.externalFlashDrive; }
            set { this.externalFlashDrive = value; }
        }
    }
}
