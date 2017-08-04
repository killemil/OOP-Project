namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class PC : Product, IPC
    {
        private string mainboard;
        private string processor;
        private string operationalMemory;
        private string graphicCard;
        private string internalMemory;
        private string opticalDrive;
        private string operationalSystem;
        private string powerSupply;

        public PC(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string mainboard, string processor, string operationalMemory, string graphicCard, string internalMemory, string opticalDrive, string operationalSystem, string powerSupply)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Mainboard = mainboard;
            this.Processor = processor;
            this.OperationalMemory = operationalMemory;
            this.GraphicCard = graphicCard;
            this.InternalMemory = internalMemory;
            this.OpticalDrive = opticalDrive;
            this.OperationalSystem = operationalSystem;
            this.PowerSupply = powerSupply;
        }

        public string Mainboard
        {
            get
            {
                return this.mainboard;
            }
            private set
            {
                this.mainboard = value;
            }
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

        public string OperationalMemory
        {
            get
            {
                return this.operationalMemory;
            }
            private set
            {
                this.operationalMemory = value;
            }
        }

        public string GraphicCard
        {
            get
            {
                return this.graphicCard;
            }
            private set
            {
                this.graphicCard = value;
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

        public string OpticalDrive
        {
            get
            {
                return this.opticalDrive;
            }
            private set
            {
                this.opticalDrive = value;
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

        public string PowerSupply
        {
            get
            {
                return this.powerSupply;
            }
            private set
            {
                this.powerSupply = value;
            }
        }
    }
}
