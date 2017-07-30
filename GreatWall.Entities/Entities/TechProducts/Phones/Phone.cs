namespace GreatWall.Entities.Entities.TechProducts.Phones
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Phone : Product,IPhone,IPowerSupply
    {
        private string simCardType;
        private string phoneMemorySlot;
        private string networkCompatibility;
        private string power;

        public Phone(string simCardType, string phoneMemorySlot, string networkCompatibility, string power, string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory) 
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.SimCardType = simCardType;
            this.PhoneMemorySlot = phoneMemorySlot;
            this.NetworkCompatibility = networkCompatibility;
            this.Power = power;
        }

        public string SimCardType
        {
            get { return this.simCardType; }
            set { this.simCardType = value; }
        }

        public string PhoneMemorySlot
        {
            get { return this.phoneMemorySlot; }
            set { this.phoneMemorySlot = value; }
        }

        public string NetworkCompatibility
        {
            get { return this.networkCompatibility; }
            set { this.networkCompatibility = value; }
        }

        public string Power
        {
            get { return this.power; }
            set { this.power = value; }
        }
    }
}
