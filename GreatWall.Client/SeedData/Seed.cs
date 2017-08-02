namespace GreatWall.Client.SeedData
{
    using GreatWall.Entities.Entities.TechProducts.Computers;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using System.Collections.Generic;
    using System.IO;
    using System;

    public static class Seed
    {
        public static IList<IProduct> SeedData()
        {
            List<IProduct> products = new List<IProduct>();

            AddProcessors(products);

            return products;
        }

        private static void AddProcessors(List<IProduct> products)
        {
            foreach (var line in File.ReadLines(@"..\..\..\Processors.txt"))
            {
                string[] tokens = line.Split();
                string model = tokens[0];
                string manufacturer = tokens[1];
                int quantity = int.Parse(tokens[2]);
                decimal price = decimal.Parse(tokens[3]);
                string color = tokens[4];
                double weight = double.Parse(tokens[5]);
                string size = tokens[6];
                string capacity = tokens[7];
                int cores = int.Parse(tokens[8]);
                Category category = (Category)1;
                SubCategory subCategory = (SubCategory)3;

                products.Add(new Processor(manufacturer, quantity, price, color, model, capacity, cores, weight, size, category, subCategory));
            }
        }
    }
}
