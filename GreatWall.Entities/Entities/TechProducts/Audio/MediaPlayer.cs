namespace GreatWall.Entities.Entities.TechProducts.Audio
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System.Text;

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
            set { this.hasRadio = value; }
        }

        public string Resolution
        {
            get { return this.resolution; }
            set { this.resolution = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
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

