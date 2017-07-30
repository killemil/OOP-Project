namespace GreatWall.Entities.Entities.TechProducts
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using GreatWall.Entities.Interfaces;

    public class Processor : Product, IProcessor
    {
        private string capacity;
        private int cores;

        public Processor(string manufacturer, int quantity, decimal price, string color, string model, string capacity, int cores, double weight, string size, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {

            this.Capacity = capacity;
            this.Cores = cores;
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
    }
}
