namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class PC : Product, IPC
    {
        private string motherboard;
        private string processor;
        private string operationalMemory;
        private string graphicCard;
        private string internalMemory;
        private string opticalDrive;
        private string operationalSystem;
        private string powerSupply;

        public PC(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string motherboard, string processor, string operationalMemory, string graphicCard, string internalMemory, string opticalDrive, string operationalSystem, string powerSupply)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Motherboard = motherboard;
            this.Processor = processor;
            this.OperationalMemory = operationalMemory;
            this.GraphicCard = graphicCard;
            this.InternalMemory = internalMemory;
            this.OpticalDrive = opticalDrive;
            this.OperationalSystem = operationalSystem;
            this.PowerSupply = powerSupply;
        }

        public string Motherboard
        {
            get
            {
                return this.motherboard;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Motherboard)} is required!");
                }

                this.motherboard = value;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Processor)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.OperationalMemory)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.GraphicCard)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.InternalMemory)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.OpticalDrive)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.OperationalSystem)} is required!");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.PowerSupply)} is required!");
                }

                this.powerSupply = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Motherboard: {this.Motherboard}");
            sb.AppendLine($"Processor: {this.Processor}");
            sb.AppendLine($"Graphic Card: {this.GraphicCard}");
            sb.AppendLine($"Internal Memory: {this.InternalMemory}");
            sb.AppendLine($"Optical Drive: {this.OpticalDrive}");
            sb.AppendLine($"Operational System: {this.OperationalSystem}");
            sb.AppendLine($"Power Supply: {this.PowerSupply}");
            sb.AppendLine($"Operational Memory: {this.OperationalMemory}");

            return sb.ToString();
        }
    }
}
