namespace GreatWall.Entities.Entities.TechProducts.Cameras
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;

    public class VideoCamera : Product
    {
        private string batteryType;
        private string batteryCapacity;
        private string memoryType;
        private string memorySpeed;
        private string memoryCapacity;
        private string lensDesign;
        private string lensManufacturer;

        public VideoCamera(string batteryType, string batteryCapacity, string memoryType, string memorySpeed, string memoryCapacity, string lensDesign, string lensManufacturer, string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.BatteryType = batteryType;
            this.BatteryCapacity = batteryCapacity;
            this.MemoryType = memoryType;
            this.MemorySpeed = memorySpeed;
            this.MemoryCapacity = memoryCapacity;
            this.LensDesign = lensDesign;
            this.LensManufacturer = lensManufacturer;
        }

        public string BatteryType
        {
            get
            {
                return this.batteryType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.BatteryType)} is required!");
                }

                this.batteryType = value;
            }
        }

        public string BatteryCapacity
        {
            get
            {
                return this.batteryCapacity;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.BatteryCapacity)} is required!");
                }

                this.batteryCapacity = value;
            }
        }

        public string MemoryType
        {
            get
            {
                return this.memoryType;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.MemoryType)} is required!");
                }

                this.memoryType = value;
            }
        }

        public string MemorySpeed
        {
            get
            {
                return this.memorySpeed;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.MemorySpeed)} is required!");
                }

                this.memorySpeed = value;
            }
        }

        public string MemoryCapacity
        {
            get
            {
                return this.memoryCapacity;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.MemoryCapacity)} is required!");
                }

                this.memoryCapacity = value;
            }
        }

        public string LensDesign
        {
            get
            {
                return this.lensDesign;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.LensDesign)} is required!");
                }

                this.lensDesign = value;
            }
        }

        public string LensManufacturer
        {
            get
            {
                return this.lensManufacturer;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.LensManufacturer)} is required!");
                }

                this.lensManufacturer = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Battery Type: {this.BatteryType}");
            sb.AppendLine($"Battery Capacity: {this.BatteryCapacity}");
            sb.AppendLine($"Memory Type: {this.MemoryType}");
            sb.AppendLine($"Memory Speed: {this.MemorySpeed}");
            sb.AppendLine($"Memory Capacity: {this.MemoryCapacity}");
            sb.AppendLine($"Lens Design: {this.LensDesign}");
            sb.AppendLine($"Lens Manufacturer: {this.LensManufacturer}");

            return sb.ToString();
        }
    }
}
