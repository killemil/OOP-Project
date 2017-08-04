namespace GreatWall.Client.Factory
{
    using GreatWall.Entities.Entities.TechProducts.Computers;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using System;
    using System.Collections.Generic;

    public static class ProductFactory
    {
        public static IProduct GetProduct(Category category, SubCategory subCategory, IList<string> data)
        {
            string model = data[0];
            string manufacturer = data[1];
            int quantity = int.Parse(data[2]);
            decimal price = decimal.Parse(data[3]);
            string color = data[4];
            double weight = double.Parse(data[5]);
            string size = data[6];

            switch (subCategory.ToString())
            {
                case "Processors":
                    return new Processor(manufacturer, quantity, price, color, model, data[6], int.Parse(data[7]), weight, size, category, subCategory);
                case "Motherboards":
                    return new Motherboard(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], int.Parse(data[9]));
                case "Batterys":
                    return new Battery(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8]);
                case "Displays":
                    return new Display(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], bool.Parse(data[8]), data[9], data[10], data[11]);
                case "GraphicCards":
                    return new GraphicCard(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9]);
                case "HardDrives":
                    return new HardDrive(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], double.Parse(data[10]), double.Parse(data[11]));
                case "Laptops":
                    return new Laptop(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], data[10], data[11], data[12], data[13], data[14]);
                case "Memorys":
                    return new Memory(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9]);
                case "PCs":
                    return new PC(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], data[10], data[11], data[12], data[13], data[14]);
                case "PowerSupplys":
                    return new PowerSupply(manufacturer, quantity, price, color, model, weight, size, category, subCategory, int.Parse(data[7]));

                default:
                    return null;
            }
        }
    }
}
