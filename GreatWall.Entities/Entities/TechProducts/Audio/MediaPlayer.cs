namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using System;
    using System.Text;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Exceptions;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class MediaPlayer : Product, IMediaPlayer
    {
        private string type;
        private int capacity;
        private string resolution;
        private bool hasRadio;

        public MediaPlayer(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, string type, int capacity, string resolution, bool hasRadio, Category category, SubCategory subCategory)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Resolution = resolution;
            this.HasRadio = hasRadio;
        }

        public bool HasRadio
        {
            get { return this.hasRadio; }

            private set { this.hasRadio = value; }
        }

        public string Resolution
        {
            get
            {
                return this.resolution;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.resolution)} is required");
                }

                this.resolution = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new NegativeNumberException($"{nameof(this.Capacity)}");
                }

                this.capacity = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"{nameof(this.Type)} is required!");
                }

                this.type = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Resolution: {this.Resolution}");
            sb.AppendLine($"Radio: {(this.hasRadio == true ? "Yes" : "No")}");
            sb.AppendLine($"Capacity: {this.Capacity}");

            return sb.ToString();
        }
    }
}