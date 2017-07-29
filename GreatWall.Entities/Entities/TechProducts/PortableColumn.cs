namespace GreatWall.Entities.Entities.TechProducts
{
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.TechInterfaces;

    public class PortableColumn : IProduct, IAudio
    {
        private string model;
        private string manufacturer;
        private int quantity;
        private decimal priceDecimal;
        private string color;
        private double weigth;
        private string size;
        private int power;
        private double signalFrequency;
        private double sensitivity;
        private bool usb;
        private bool microphone;
        private bool radio;
        private bool bluetooth;
        private Category category;
        private SubCategory subCategory;

        public PortableColumn(string model, string manufacturer, int quantity, decimal price, string color, double weight, string size, int power, double signalFrequency, double sensitivity, bool usb, bool bluetooth, bool microphone, bool radio, Category category, SubCategory subCategory)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Quantity = quantity;
            this.Price = price;
            this.Color = color;
            this.Weight = weight;
            this.Size = size;
            this.Power = power;
            this.SignalFrequency = signalFrequency;
            this.Sensitivity = sensitivity;
            this.USB = usb;
            this.Microphone = microphone;
            this.Radio = radio;
            this.Bluetooth = bluetooth;
            this.Category = category;
            this.SubCategory = subCategory;
        }

        public bool Bluetooth
        {
            get { return bluetooth; }
            set { bluetooth = value; }
        }


        public bool Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        public bool Microphone
        {
            get { return microphone; }
            set { microphone = value; }
        }

        public bool USB
        {
            get { return usb; }
            set { usb = value; }
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
