namespace GreatWall.Entities.Entities.TechProducts
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    public class MediaPlayer : IProduct
    {
        private string model;
        private string manufacturer;
        private int quantity;
        private decimal priceDecimal;
        private string color;
        private double weigth;
        private string size;
        private string type;
        private int capacity;
        private string resolution;
        private bool radio;
        private Category category;
        private SubCategory subCategory;

        public MediaPlayer(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, string type, int capacity, string resolution, bool radio, Category category, SubCategory subCategory)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Quantity = quantity;
            this.Price = price;
            this.Color = color;
            this.Weight = weight;
            this.Size = size;
            this.Type = type;
            this.Capacity = capacity;
            this.Resolution = resolution;
            this.Radio = radio;
            this.Category = category;
            this.SubCategory = subCategory;
        }


        public bool Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        public string Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public double Weight
        {
            get { return weigth; }
            set { weigth = value; }
        }


        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public decimal Price
        {
            get { return priceDecimal; }
            set { priceDecimal = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Category Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                this.category = value;
            }
        }

        public SubCategory SubCategory
        {
            get
            {
                return this.subCategory;
            }
            private set
            {
                this.subCategory = value;
            }

        }
    }
}

