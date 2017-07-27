namespace GreatWall.Entities.Entities.TechProducts
{
    using System;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Processor : IProcessor
    {
        private string name;
        private string manufacturer;
        private int quantity;
        private decimal price;
        private string color;
        private string model;
        private string capacity;
        private int cores;
        private double weight;
        private string size;

        public Processor(string name, string manufacturer, int quantity, decimal price, string color, string model, string capacity, int cores, double weight, string size)
        {
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Quantity = quantity;
            this.Price = price;
            this.Color = color;
            this.Model = model;
            this.Capacity = capacity;
            this.Cores = cores;
            this.Weight = weight;
            this.Size = size;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public string Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int Cores
        {
            get { return this.cores; }
            private set { this.cores = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                this.manufacturer = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            private set
            {
                this.quantity = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                this.color = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                this.weight = value;
            }
        }

        public string Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                this.size = value;
            }
        }
    }
}
