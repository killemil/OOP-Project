namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System.Text;

    public class HardDrive : Product, IHardDrive
    {
        private string hardDriveType;
        private string hardDriveCapacity;
        private string hardDriveInterface;
        private double hardDriveWriteSpeed;
        private double hardDriveReadSpeed;

        public HardDrive(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string hardDriveType, string hardDriveCapacity, string hardDriveInterface, double hardDriveWriteSpeed, double hardDriveReadSpeed)
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
            get { return this.hardDriveType; }
            private set { this.hardDriveType = value; }
        }
        public string HardDriveCapacity
        {
            get { return this.hardDriveCapacity; }
            private set { this.hardDriveCapacity = value; }
        }
        public string HardDriveInterface
        {
            get { return this.hardDriveInterface; }
            private set { this.hardDriveInterface = value; }
        }
        public double HardDriveWriteSpeed
        {
            get { return this.hardDriveWriteSpeed; }
            private set { this.hardDriveWriteSpeed = value; }
        }
        public double HardDriveReadSpeed
        {
            get { return this.hardDriveReadSpeed; }
            private set { this.hardDriveReadSpeed = value; }
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
