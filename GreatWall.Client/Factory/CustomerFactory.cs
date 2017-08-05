
namespace GreatWall.Client.Factory
{
    using GreatWall.Entities.Entities.Customers;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Customers;
    using System.Collections.Generic;

    public static class CustomerFactory
    {
        public static ICustomer CreateCustomer(IList<string> customerData, IProduct product)
        {
            string name = customerData[0];
            string address = customerData[1];
            string telephoneNumber = customerData[2];
            int wantedNumberOfProducts = int.Parse(customerData[3]);
            ICustomer customer = new Customer(name, address, telephoneNumber);
            customer.AddProduct(product, wantedNumberOfProducts);

            return customer;
        }
    }
}
