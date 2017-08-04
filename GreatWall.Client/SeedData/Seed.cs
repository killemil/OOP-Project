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
            AddMotherboards(products);
            AddBatteries(products);

            return products;
        }

        private static void AddBatteries(List<IProduct> products)
        {
            foreach (var line in File.ReadLines(@"..\..\..\SeedData\Batteries.txt"))
            {
                string[] tokens = line.Split();

                string model = tokens[4];
                string manufacturer = tokens[0];
                int quantity = int.Parse(tokens[1]);
                decimal price = decimal.Parse(tokens[2]);
                string color = tokens[3];
                double weight = double.Parse(tokens[5]);
                string size = tokens[6];
                string type = tokens[7];
                string capacity = tokens[8];
                Category category = (Category)100;
                SubCategory subCategory = (SubCategory)(4 + (int)category);

                products.Add(new Battery(manufacturer, quantity, price, color, model, weight, size, category, subCategory, type, capacity));
            }
        }

        private static void AddMotherboards(List<IProduct> products)
        {
            foreach (var line in File.ReadLines(@"..\..\..\SeedData\Motherboards.txt"))
            {
                string[] tokens = line.Split();

                string model = tokens[4];
                string manufacturer = tokens[0];
                int quantity = int.Parse(tokens[1]);
                decimal price = decimal.Parse(tokens[2]);
                string color = tokens[3];
                double weight = double.Parse(tokens[5]);
                string size = tokens[6];
                string cpuSocket = tokens[7];
                string videoSlot = tokens[8];
                int maxRam = int.Parse(tokens[9]);
                Category category = (Category)100;
                SubCategory subCategory = (SubCategory)(10 + (int)category);

                products.Add(new Motherboard(manufacturer, quantity, price, color, model, weight, size, category, subCategory, cpuSocket, videoSlot, maxRam));
            }
        }

        private static void AddProcessors(List<IProduct> products)
        {
            foreach (var line in File.ReadLines(@"..\..\..\SeedData\Processors.txt"))
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
                Category category = (Category)100;
                SubCategory subCategory = (SubCategory)(3 + (int)category);

                products.Add(new Processor(manufacturer, quantity, price, color, model, capacity, cores, weight, size, category, subCategory));
            }
        }
    }
}
