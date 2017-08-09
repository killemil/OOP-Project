namespace GreatWall.Client.Repositories
{
    using System.Collections.Generic;
    using GreatWall.Client.Factory;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Customers;
    using GreatWall.Entities.Interfaces.Repository;

    public class CustomerRepository : IClientRepository<ICustomer>
    {
        private IList<ICustomer> data;

        public CustomerRepository()
        {
            this.Data = new List<ICustomer>();
        }

        public IList<ICustomer> Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                this.data = value;
            }
        }

        public void Add(IList<string> customerDetails, IProduct currentProduct)
        {
            ICustomer customer = CustomerFactory.CreateCustomer(customerDetails, currentProduct);
            this.Data.Add(customer);
        }
    }
}