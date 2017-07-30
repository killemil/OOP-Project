namespace GreatWall.Entities.Interfaces
{
    using GreatWall.Entities.Enumerations;

    public abstract class Product : IProduct
    {
        private string manufacturer;
        private int quantity;
        private decimal price;
        private string color;
        private string model;
        private double weight;
        private string size;
        private Category category;
        private SubCategory subCategory;

        public Product(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory)
        {
            this.Manufacturer = manufacturer;
            this.Quantity = quantity;
            this.Price = price;
            this.Color = color;
            this.Model = model;
            this.Weight = weight;
            this.Size = size;
            this.Category = Category;
            this.SubCategory = SubCategory;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            private set
            {
                this.manufacturer = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            private set
            {
                this.quantity = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                this.color = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                this.weight = value;
            }
        }

        public string Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                this.size = value;
            }
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
