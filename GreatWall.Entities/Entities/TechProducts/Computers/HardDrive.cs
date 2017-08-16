namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class HardDrive : Product, IHardDrive
    {
        private string hardDriveType;
        private string hardDriveCapacity;
        private string hardDriveInterface;
        private double hardDriveWriteSpeed;
        private double hardDriveReadSpeed;

        public HardDrive(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, string hardDriveType, string hardDriveCapacity, string hardDriveInterface, double hardDriveWriteSpeed, double hardDriveReadSpeed)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.HardDriveType = hardDriveType;
            this.HardDriveCapacity = hardDriveCapacity;
            this.HardDriveInterface = hardDriveInterface;
            this.HardDriveWriteSpeed = hardDriveWriteSpeed;
            this.HardDriveReadSpeed = hardDriveReadSpeed;
        }

        public string HardDriveType
        {
            get
            {
                return this.hardDriveType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.HardDriveType)} is required!");
                }

                this.hardDriveType = value;
            }
        }

        public string HardDriveCapacity
        {
            get
            {
                return this.hardDriveCapacity;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.HardDriveCapacity)} is required!");
                }

                this.hardDriveCapacity = value;
            }
        }

        public string HardDriveInterface
        {
            get
            {
                return this.hardDriveInterface;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.HardDriveInterface)} is required!");
                }

                this.hardDriveInterface = value;
            }
        }

        public double HardDriveWriteSpeed
        {
            get
            {
                return this.hardDriveWriteSpeed;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.HardDriveWriteSpeed));
                }

                this.hardDriveWriteSpeed = value;
            }
        }

        public double HardDriveReadSpeed
        {
            get
            {
                return this.hardDriveReadSpeed;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.HardDriveReadSpeed));
                }

                this.hardDriveReadSpeed = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Hard Drive Type: {this.HardDriveType}");
            sb.AppendLine($"Hard Drive Capacity: {this.HardDriveCapacity}");
            sb.AppendLine($"Hard Drive Interface: {this.HardDriveInterface}");
            sb.AppendLine($"Hard Drive Write Speed: {this.HardDriveWriteSpeed}");
            sb.AppendLine($"Hard Drive Read Speed: {this.HardDriveReadSpeed}");

            return sb.ToString();
        }
    }
}
