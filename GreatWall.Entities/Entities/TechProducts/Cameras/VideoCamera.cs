namespace GreatWall.Entities.Entities.TechProducts.Cameras
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class VideoCamera : Product, IBattery, IMemory, ILens, IExternalFlashDrive
    {
        private string batteryType;
        private string batteryCapacity;
        private string memoryType;
        private string memorySpeed;
        private string memoryCapacity;
        private string lensDesign;
        private string lensManufacturer;
        private bool externalFlashDrive;

        public VideoCamera(string batteryType, string batteryCapacity, string memoryType, string memorySpeed,
            string memoryCapacity, string lensDesign, string lensManufacturer, bool externalFlashDrive, 
            string manufacturer, int quantity, decimal price, string color, string model,
            double weight, string size, Category category, SubCategory subCategory) 
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.BatteryType = batteryType;
            this.BatteryCapacity = batteryCapacity;
            this.MemoryType = memoryType;
            this.MemorySpeed = memorySpeed;
            this.MemoryCapacity = memoryCapacity;
            this.LensDesign = lensDesign;
            this.LensManufacturer = lensManufacturer;
            this.ExternalFlashDrive = externalFlashDrive;
        }

        public string BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        public string BatteryCapacity
        {
            get { return this.batteryCapacity; }
            set { this.batteryCapacity = value; }
        }

        public string MemoryType
        {
            get { return this.memoryType; }
            set { this.memoryType = value; }
        }

        public string MemorySpeed
        {
            get { return this.memorySpeed; }
            set { this.memorySpeed = value; }
        }

        public string MemoryCapacity
        {
            get { return this.memoryCapacity; }
            set { this.memoryCapacity = value; }
        }

        public string LensDesign
        {
            get { return this.lensDesign; }
            set { this.lensDesign = value; }
        }

        public string LensManufacturer
        {
            get { return this.lensManufacturer; }
            set { this.lensManufacturer = value; }
        }

        public bool ExternalFlashDrive
        {
            get { return this.externalFlashDrive; }
            set { this.externalFlashDrive = value; }
        }
    }
}
