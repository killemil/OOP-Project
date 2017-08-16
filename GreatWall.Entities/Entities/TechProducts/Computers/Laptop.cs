namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Laptop : Product, ILaptop
    {
        private string processor;
        private string operationalMemory;
        private string graphicCard;
        private string internalMemory;
        private string displaySizeAndResolution;
        private string opticalDrive;
        private string battery;
        private string operationalSystem;

        public Laptop(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string processor, string operationaMemory, string graphicCard, string internalMemory, string displayResolutionAndSize, string opticalDrive, string battery, string operationalSystem)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Processor = processor;
            this.OperationalMemory = operationaMemory;
            this.GraphicCard = graphicCard;
            this.InternalMemory = internalMemory;
            this.DisplaySizeAndResolution = displayResolutionAndSize;
            this.OpticalDrive = opticalDrive;
            this.Battery = battery;
            this.OperationalSystem = operationalSystem;
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

        public string DisplaySizeAndResolution
        {
            get
            {
                return this.displaySizeAndResolution;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.DisplaySizeAndResolution)} is required!");
                }

                this.displaySizeAndResolution = value;
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

        public string Battery
        {
            get
            {
                return this.battery;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Battery)} is required!");
                }

                this.battery = value;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Processor: {this.Processor}");
            sb.AppendLine($"Operational Memory: {this.OperationalMemory}");
            sb.AppendLine($"Graphic Card: {this.GraphicCard}");
            sb.AppendLine($"Internal Memory: {this.InternalMemory}");
            sb.AppendLine($"Display Size and Resolution: {this.DisplaySizeAndResolution}");
            sb.AppendLine($"Optical Drive: {this.OpticalDrive}");
            sb.AppendLine($"Battery: {this.Battery}");
            sb.AppendLine($"Operational System: {this.OperationalSystem}");

            return sb.ToString();
        }
    }
}
