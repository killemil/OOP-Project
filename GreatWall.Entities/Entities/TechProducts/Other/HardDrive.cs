namespace GreatWall.Entities.Entities.TechProducts.Other
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class HardDrive : Product, IHardDrive
    {
        private string hardDriveType;
        private string hardDriveCapacity;
        private string hardDriveInterface;
        private double hardDriveWriteSpeed;
        private double hardDriveReadSpeed;

        public HardDrive(string hardDriveType, string hardDriveCapacity,
            string hardDriveInterface, double hardDriveWriteSpeed, double hardDriveReadSpeed, 
            string manufacturer, int quantity, decimal price, string color, string model, double weight,
            string size, Category category, SubCategory subCategory)
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
    }
}
