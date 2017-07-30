﻿namespace GreatWall.Entities.Entities.TechProducts
{
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Enumerations;

    public class Column : IProduct, IAudio
    {
        private string model;
        private string manufacturer;
        private int quantity;
        private decimal priceDecimal;
        private string color;
        private double weigth;
        private string size;
        private int power;
        private double signalFrequency;
        private double sensitivity;
        private Category category;
        private SubCategory subCategory;


        public Column(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, int power, double signalFrequency, double sensitivity, Category category, SubCategory subCategory)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Quantity = quantity;
            this.Price = price;
            this.Color = color;
            this.Weight = weight;
            this.Size = size;
            this.Power = power;
            this.SignalFrequency = signalFrequency;
            this.Sensitivity = sensitivity;
            this.Category = category;
            this.SubCategory = subCategory;
        }

        public double Sensitivity
        {
            get { return sensitivity; }
            set { sensitivity = value; }
        }

        public double SignalFrequency
        {
            get { return signalFrequency; }
            set { signalFrequency = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public double Weight
        {
            get { return weigth; }
            set { weigth = value; }
        }


        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public decimal Price
        {
            get { return priceDecimal; }
            set { priceDecimal = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Category Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                this.category = value;
            }
        }

        public SubCategory SubCategory
        {
            get
            {
                return this.subCategory;
            }
            private set
            {
                this.subCategory = value;
            }
        }
    }
}