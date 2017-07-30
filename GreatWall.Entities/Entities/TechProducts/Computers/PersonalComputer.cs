namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    class PersonalComputer : Product, IDisplay, IGraphicCard, IHardDrive, IMemory, IMotherboard, IOperationalSystem,IPowerSupply, IProcessor
    {
        private string displayType;
        private bool touchScreen;
        private string displayResolution;
        private string displaySizeInInches;
        private string displayColors;
        private string videoCardSlot;
        private string videoCardModel;
        private string videoCardMemoryType;
        private string videoCardMemoryCapacity;
        private string hardDriveType;
        private string hardDriveCapacity;
        private string hardDriveInterface;
        private double hardDriveWriteSpeed;
        private double hardDriveReadSpeed;
        private string memoryType;
        private string memorySpeed;
        private string memoryCapacity;
        private string cPUSocket;
        private string motherboardChipset;
        private string maxRamCapacity;
        private string oSType;
        private string oSManufacturer;
        private string power;
        private string capacity;
        private int cores;


        public PersonalComputer(string displayType, bool touchScreen, string displayResolution,
            string displaySizeInInches, string displayColors, string videoCardSlot, string videoCardModel,
            string videoCardMemoryType, string videoCardMemoryCapacity, string hardDriveType, string hardDriveCapacity,
            string hardDriveInterface, double hardDriveWriteSpeed, double hardDriveReadSpeed, string memoryType,
            string memorySpeed, string memoryCapacity, string cPUSocket, string motherboardChipset,
            string maxRamCapacity, string oSType, string oSManufacturer,string power, string capacity,int cores,
            string manufacturer, int quantity, decimal price,
            string color, string model,
            double weight, string size, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.DisplayType = displayType;
            this.TouchScreen = touchScreen;
            this.DisplayResolution = displayResolution;
            this.DisplaySizeInInches = displaySizeInInches;
            this.DisplayColors = displayColors;
            this.VideoCardSlot = videoCardSlot;
            this.VideoCardModel = videoCardModel;
            this.VideoCardMemoryType = videoCardMemoryType;
            this.VideoCardMemoryCapacity = videoCardMemoryCapacity;
            this.HardDriveType = hardDriveType;
            this.HardDriveCapacity = hardDriveCapacity;
            this.HardDriveInterface = hardDriveInterface;
            this.HardDriveWriteSpeed = hardDriveWriteSpeed;
            this.HardDriveReadSpeed = hardDriveReadSpeed;
            this.MemoryType = memoryType;
            this.MemorySpeed = memorySpeed;
            this.MemoryCapacity = memoryCapacity;
            this.CPUSocket = cPUSocket;
            this.MotherboardChipset = motherboardChipset;
            this.MaxRamCapacity = maxRamCapacity;
            this.OSType = oSType;
            this.OSManufacturer = oSManufacturer;
            this.Power = power;
            this.Capacity = capacity;
            this.Cores = cores;
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

        public string VideoCardSlot
        {
            get { return this.videoCardSlot; }
            set { this.videoCardSlot = value; }
        }
        public string VideoCardModel
        {
            get { return this.videoCardModel; }
            set { this.videoCardModel = value; }
        }
        public string VideoCardMemoryType
        {
            get { return this.videoCardMemoryType; }
            set { this.videoCardMemoryType = value; }
        }
        public string VideoCardMemoryCapacity
        {
            get { return this.videoCardMemoryCapacity; }
            set { this.videoCardMemoryCapacity = value; }
        }

        public string HardDriveType
        {
            get { return this.hardDriveType; }
            set { this.hardDriveType = value; }
        }
        public string HardDriveCapacity
        {
            get { return this.hardDriveCapacity; }
            set { this.hardDriveCapacity = value; }
        }
        public string HardDriveInterface
        {
            get { return this.hardDriveInterface; }
            set { this.hardDriveInterface = value; }
        }
        public double HardDriveWriteSpeed
        {
            get { return this.hardDriveWriteSpeed; }
            set { this.hardDriveWriteSpeed = value; }
        }
        public double HardDriveReadSpeed
        {
            get { return this.hardDriveReadSpeed; }
            set { this.hardDriveReadSpeed = value; }
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

        public string CPUSocket
        {
            get { return this.cPUSocket; }
            set { this.cPUSocket = value; }
        }
        public string MotherboardChipset
        {
            get { return this.motherboardChipset; }
            set { this.motherboardChipset = value; }
        }
        public string MaxRamCapacity
        {
            get { return this.maxRamCapacity; }
            set { this.maxRamCapacity = value; }
        }

        public string OSType
        {
            get { return this.oSType; }
            set { this.oSType = value; }
        }
        public string OSManufacturer
        {
            get { return this.oSManufacturer; }
            set { this.oSManufacturer = value; }
        }

        public string Power
        {
            get { return this.power; }
            set { this.power = value; }
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
