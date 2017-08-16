namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class PowerSupply : Product, IPowerSupply
    {
        private int power;

        public PowerSupply(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory, int power) 
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            {
                return this.power;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException(nameof(this.Power));
                }

                this.power = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Power: {this.Power}");

            return sb.ToString();
        }
    }
}
