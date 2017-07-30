﻿namespace GreatWall.Entities.Entities.TechProducts.Other
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Battery : Product, IBattery
    {
        private string batteryType;
        private string batteryCapacity;

        public Battery(string batteryType, string batteryCapacity, string manufacturer, int quantity, decimal price, string color, string model, double weight, 
            string size, Category category, SubCategory subCategory) 
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.BatteryType = batteryType;
            this.BatteryCapacity = batteryCapacity;
        }

        public string BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }
        public string BatteryCapacity
        {
            get { return this.batteryCapacity; }
            set { this.batteryCapacity = value; }
        }
    }
}
