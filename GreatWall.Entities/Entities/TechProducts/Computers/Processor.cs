﻿namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

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
            get
            {
                return this.capacity;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Capacity)} is required!");
                }

                this.capacity = value;
            }
        }

        public int Cores
        {
            get
            {
                return this.cores;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.Cores));
                }

                this.cores = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Capacity(Ghz): {this.Capacity}");
            sb.AppendLine($"Number of cores: {this.Cores}");

            return sb.ToString();
        }
    }
}
