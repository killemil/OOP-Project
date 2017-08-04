namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class Amplifier : Product, IAmplifier
    {
        private int power;
        private string channels;
        private bool hasTuner;
        private bool hasRemoteControl;

        public Amplifier(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, Category category, SubCategory subCategory,
             int power, string channels, bool hasTuner, bool hasRemoteControl)
            : base(manufacturer,quantity,price,color,model,weight,size,category,subCategory)
        {
            this.Power = power;
            this.Channels = channels;
            this.HasTuner = hasTuner;
            this.HasRemoteControl = hasRemoteControl;
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public string Channels
        {
            get
            {
                return this.channels;
            }
            private set
            {
                this.channels = value;
            }
        }

        public bool HasTuner
        {
            get
            {
                return this.hasTuner;
            }
            private set
            {
                this.hasTuner = value;
            }
        }

        public bool HasRemoteControl
        {
            get
            {
                return this.hasRemoteControl;
            }
            private set
            {
                this.hasRemoteControl = value;
            }
        }
    }
}
