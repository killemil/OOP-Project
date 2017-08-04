namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Headphone : Product, IHeadphone
    {
        private int power;
        private int signalFrequency;
        private bool hasCable;
        private double diameter;

        public Headphone(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, Category category, SubCategory subCategory,
             int power, int signalFrequency, bool hasCable, double diameter)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Power = power;
            this.SignalFrequency = signalFrequency;
            this.HasCable = hasCable;
            this.Diameter = diameter;
        }

        public int SignalFrequency
        {
            get { return signalFrequency; }
            set { signalFrequency = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public bool HasCable
        {
            get
            {
                return this.hasCable;
            }
            private set
            {
                this.hasCable = value;
            }
        }

        public double Diameter
        {
            get
            {
                return this.diameter;
            }
            private set
            {
                this.diameter = value;
            }
        }
    }
}
