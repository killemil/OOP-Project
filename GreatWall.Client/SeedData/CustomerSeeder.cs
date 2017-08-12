namespace GreatWall.Client.SeedData
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using GreatWall.Entities.Entities.Customers;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Customers;

    public class CustomerSeeder
    {
        public IList<ICustomer> Seed(IList<IProduct> products)
        {
            IList<ICustomer> customers = new List<ICustomer>();
            foreach (var line in File.ReadLines(@"..\..\..\SeedData\Customers.txt"))
            {
                Random rnd = new Random();
                int index = rnd.Next(products.Count);

                string[] tokens = line.Split();

                string name = tokens[0];
                string address = tokens[1];
                string telephone = tokens[2];

                ICustomer customer = new Customer(name, address, telephone);
                customer.AddProduct(products[index], 1);

                customers.Add(customer);
            }

            return customers;
        }
    }
}
