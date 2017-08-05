﻿namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System.Text;

    public class Memory : Product, IMemory
    {
        private string type;
        private string speed;
        private string capacity;

        public Memory(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string type, string speed, string capacity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Type = type;
            this.Speed = speed;
            this.Capacity = capacity;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                this.type = value;
            }
        }

        public string Speed
        {
            get
            {
                return this.speed;
            }
            private set
            {
                this.speed = value;
            }
        }

        public string Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Speed: {this.Speed}");
            sb.AppendLine($"Capacity: {this.Capacity}");

            return sb.ToString();
        }
    }
}
