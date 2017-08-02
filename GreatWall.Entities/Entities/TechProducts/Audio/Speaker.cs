namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Enumerations;

    public class Speaker : Product, IAudio
    {
        private int power;
        private double signalFrequency;
        private double sensitivity;


        public Speaker(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, int power, double signalFrequency, double sensitivity, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Power = power;
            this.SignalFrequency = signalFrequency;
            this.Sensitivity = sensitivity;
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
