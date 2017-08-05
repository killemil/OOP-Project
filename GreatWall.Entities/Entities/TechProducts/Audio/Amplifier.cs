namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System;
    using System.Text;

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
            get { return this.power; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Power cannot be negative number!");
                }
                this.power = value;
            }
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Power(Wats): {this.Power}");
            sb.AppendLine($"Number of channels: {this.Channels}");
            sb.AppendLine($"Tuner: {(this.HasTuner == true ? "Yes" : "No")}");
            sb.AppendLine($"Remote Control: {(this.HasRemoteControl == true ? "Yes" : "No")}");

            return sb.ToString();
        }
    }
}
