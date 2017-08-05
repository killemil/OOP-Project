namespace GreatWall.Entities.Entities.Customers
{
    using System;
    using System.Collections.Generic;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Customers;

    public class Customer : ICustomer
    {
        private string name;
        private string address;
        private string telephoneNumber;
        private IDictionary<IProduct,int> products;

        public Customer(string name, string address, string telephoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.TelephoneNumber = telephoneNumber;
            this.Products = new Dictionary<IProduct, int>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            private set
            {
                this.address = value;
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return this.telephoneNumber;
            }
            private set
            {
                this.telephoneNumber = value;
            }
        }

        public IDictionary<IProduct,int> Products
        {
            get
            {
                return this.products;
            }
            private set
            {
                this.products = value;
            }
        }

        public void AddProduct(IProduct product, int quantity)
        {
            if (product != null)
            {
                this.Products.Add(product, quantity);
            }
        }
    }
}
