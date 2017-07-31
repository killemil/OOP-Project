namespace GreatWall.Entities.Entities.TechProducts.Phones
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class SmartPhone : Product, IPhone, IPowerSupply, IBattery, IDisplay, IMemory, IProcessor
    {
        private string simCardType;
        private string phoneMemorySlot;
        private string networkCompatibility;
        private string power;
        private string batteryType;
        private string batteryCapacity;
        private string displayType;
        private bool touchScreen;
        private string displayResolution;
        private string displaySizeInInches;
        private string displayColors;
        private string memoryType;
        private string memorySpeed;
        private string memoryCapacity;
        private string capacity;
        private int cores;

        public SmartPhone(string simCardType, string phoneMemorySlot, string networkCompatibility,
            string power, string batteryType, string batteryCapacity,
            string displayType, bool touchScreen, string displayResolution,
            string displaySizeInInches, string displayColors, string memoryType,
            string memorySpeed, string memoryCapacity, string capacity, int cores, string manufacturer,
            int quantity, decimal price, string color, string model, double weight,
            string size, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.SimCardType = simCardType;
            this.PhoneMemorySlot = phoneMemorySlot;
            this.NetworkCompatibility = networkCompatibility;
            this.Power = power;
            this.BatteryType = batteryType;
            this.BatteryCapacity = batteryCapacity;
            this.DisplayType = displayType;
            this.TouchScreen = touchScreen;
            this.DisplayResolution = displayResolution;
            this.DisplaySizeInInches = displaySizeInInches;
            this.DisplayColors = displayColors;
            this.MemoryType = memoryType;
            this.MemorySpeed = memorySpeed;
            this.MemoryCapacity = memoryCapacity;
            this.Capacity = capacity;
            this.Cores = cores;
        }

        public string SimCardType
        {
            get { return this.simCardType; }
            set { this.simCardType = value; }
        }

        public string PhoneMemorySlot
        {
            get { return this.phoneMemorySlot; }
            set { this.phoneMemorySlot = value; }
        }

        public string NetworkCompatibility
        {
            get { return this.networkCompatibility; }
            set { this.networkCompatibility = value; }
        }

        public string Power
        {
            get { return this.power; }
            set { this.power = value; }
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

        public string Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public int Cores
        {
            get { return this.cores; }
            set { this.cores = value; }
        }
    }
}
