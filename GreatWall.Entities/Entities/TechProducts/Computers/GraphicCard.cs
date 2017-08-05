namespace GreatWall.Entities.Entities.TechProducts.Computers
{
    using System;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces.TechInterfaces;
    using System.Text;

    public class GraphicCard : Product, IGraphicCard
    {
        private string slotType;
        private string memoryType;
        private string memoryCapacity;

        public GraphicCard(string manufacturer, int quantity, decimal price, string color, string model, double weight, string size, Category category, SubCategory subCategory,
            string slotType, string memoryType, string memoryCapacity)
            : base(manufacturer, quantity, price, color, model, weight, size, category, subCategory)
        {
            this.SlotType = slotType;
            this.MemoryType = memoryType;
            this.MemoryCapacity = memoryCapacity;
        }

        public string SlotType
        {
            get
            {
                return this.slotType;
            }
            private set
            {
                this.slotType = value;
            }
        }

        public string MemoryType
        {
            get
            {
                return this.memoryType;
            }
            private set
            {
                this.memoryType = value;
            }
        }

        public string MemoryCapacity
        {
            get
            {
                return this.memoryCapacity;
            }
            private set
            {
                this.memoryCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Slot Type: {this.SlotType}");
            sb.AppendLine($"Memory Type: {this.MemoryType}");
            sb.AppendLine($"Memory Capacity: {this.MemoryCapacity}");

            return sb.ToString();
        }
    }
}
