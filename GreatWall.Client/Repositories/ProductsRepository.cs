namespace GreatWall.Client.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using GreatWall.Client.Factory;
    using GreatWall.Client.SeedData;
    using GreatWall.Entities.Entities.Console;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Console;
    using GreatWall.Entities.Interfaces.Customers;
    using GreatWall.Entities.Interfaces.Repository;

    public class ProductsRepository : IRepository
    {
        private IList<IProduct> products;
        private IList<ICustomer> customers;
        private IWriter writer;
        private IReader reader;

        public ProductsRepository()
        {
            this.Products = new List<IProduct>(ProductsSeed.SeedData());
            this.Customers = new List<ICustomer>(CustomersSeed.Seed(this.Products));
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public IList<IProduct> Products
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

        public IList<ICustomer> Customers
        {
            get
            {
                return this.customers;
            }

            private set
            {
                this.customers = value;
            }
        }

        public void AddProduct(Category category, SubCategory subCategory, IList<string> productData)
        {
            string categoryStr = category.ToString();
            string subCategoryStr = subCategory.ToString();

            this.Products.Add(ProductFactory.GetProduct(category, subCategory, productData));
        }

        public void AddClient(IList<string> customerDetails, IProduct currentProduct)
        {
            ICustomer customer = CustomerFactory.CreateCustomer(customerDetails, currentProduct);
            this.Customers.Add(customer);
        }

        public IList<ICustomer> GetAllCustomers()
        {
            return this.Customers.ToList();
        }

        public IList<IProduct> GetProductData(SubCategory subcategory)
        {
            return this.Products.Where(p => p.SubCategory == subcategory).ToList();
        }

        public void RemoveProduct(IProduct currentProduct, int quantity)
        {
            if (currentProduct.Quantity - quantity == 0)
            {
                this.Products.Remove(currentProduct);
                return;
            }

            this.Products.First(p => p == currentProduct).Quantity -= quantity;
        }
    }
}