namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Amplifier : Product, IAudio
    {
        private int power;
        private double signalFrequency;
        private double sensitivity;
        private string signalType;

        public Amplifier(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, int power, double signalFrequency, double sensitivity, string signalType, Category category, SubCategory subCategory)
            : base(manufacturer,quantity,price,color,model,weight,size,category,subCategory)
        {
            this.Power = power;
            this.SignalFrequency = signalFrequency;
            this.Sensitivity = sensitivity;
            this.SignalType = signalType;
        }

        public string SignalType
        {
            get { return signalType; }
            set { signalType = value; }
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
    }
}
