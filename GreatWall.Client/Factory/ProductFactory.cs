namespace GreatWall.Client.Factory
{
    using GreatWall.Entities.Entities.TechProducts;
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
                    Console.Write("Capacity(Ghz): ");
                    string capacity = Console.ReadLine();
                    Console.Write("Cores: ");
                    int cores = int.Parse(Console.ReadLine());
                    return new Processor(manufacturer, quantity, price, color, model, capacity, cores, weight, size, category, subCategory);
                default:
                    return null;
            }
        }
    }
}
