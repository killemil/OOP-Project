namespace GreatWall.Entities.Entities.TechProducts.Phones
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class SmartPhone : Product, ISmartPhone
    {
        private string processor;
        private string ramMemory;
        private string internalMemory;
        private string displayType;
        private string displaySize;
        private string operationalSystem;
        private string simCardType;
        private string memorySlot;
        private string networkCompatibility;
        private int batteryCapacity;

        public SmartPhone(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string simCardType, string memorySlot, string networkCompatibility, int batteryCapacity, string procesor, string ramMemory, string internalMemory, string displayType, string displaySize, string operationalSystem)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Processor = procesor;
            this.RamMemory = ramMemory;
            this.InternalMemory = internalMemory;
            this.DisplayType = displayType;
            this.DisplaySize = displaySize;
            this.OperationalSystem = operationalSystem;
            this.SimCardType = simCardType;
            this.MemorySlot = memorySlot;
            this.NetworkCompatibility = networkCompatibility;
            this.BatteryCapacity = batteryCapacity;
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }
            private set
            {
                this.processor = value;
            }
        }

        public string RamMemory
        {
            get
            {
                return this.ramMemory;
            }
            private set
            {
                this.ramMemory = value;
            }
        }

        public string InternalMemory
        {
            get
            {
                return this.internalMemory;
            }
            private set
            {
                this.internalMemory = value;
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

        public string DisplaySize
        {
            get
            {
                return this.displaySize;
            }
            private set
            {
                this.displaySize = value;
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

        public string SimCardType
        {
            get { return this.simCardType; }
            set { this.simCardType = value; }
        }

        public string MemorySlot
        {
            get { return this.memorySlot; }
            set { this.memorySlot = value; }
        }

        public string NetworkCompatibility
        {
            get { return this.networkCompatibility; }
            set { this.networkCompatibility = value; }
        }

        public int BatteryCapacity
        {
            get
            {
                return this.batteryCapacity;
            }
            private set
            {
                this.batteryCapacity = value;
            }
        }
    }
}
