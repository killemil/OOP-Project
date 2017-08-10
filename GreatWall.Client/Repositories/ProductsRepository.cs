namespace GreatWall.Client.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GreatWall.Client.Factory;
    using GreatWall.Client.SeedData;
    using GreatWall.Client.StaticData;
    using GreatWall.Entities.Entities.Console;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Console;
    using GreatWall.Entities.Interfaces.Repository;
    using GreatWall.Entities.Interfaces.Customers;

    public class ProductsRepository : IRepository
    {
        private IList<IProduct> products;
        private IList<ICustomer> customers;
        private IWriter writer;
        private IReader reader;

        public ProductsRepository()
        {
            this.Products = new List<IProduct>(Seed.SeedData());
            this.Customers = new List<ICustomer>();
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

        public void AddProduct(Category category, SubCategory subCategory)
        {
            string categoryStr = category.ToString();
            string subCategoryStr = subCategory.ToString();

            IList<string> productData = this.GetProductData(categoryStr, subCategoryStr);
            this.Products.Add(ProductFactory.GetProduct(category, subCategory, productData));
        }

        public void AddClient(IList<string> customerDetails, IProduct currentProduct)
        {
            ICustomer customer = CustomerFactory.CreateCustomer(customerDetails, currentProduct);
            this.Customers.Add(customer);
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

        private IList<string> GetProductData(string currentCategoryStr, string currentSubCategoryStr)
        {
            string className = currentSubCategoryStr.Substring(0, currentSubCategoryStr.Length - 1);
            Type currentClass = Type.GetType(Constants.ClassesNamespace + currentCategoryStr + "." + className + Constants.AssemblyName);
            PropertyInfo[] baseProperties = currentClass.BaseType.GetProperties();
            PropertyInfo[] currentClassProperties = currentClass.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            IList<string> productData = new List<string>();
            for (int i = 0; i < baseProperties.Length - 2; i++)
            {
                string propertyType = baseProperties[i].PropertyType.Name;
                this.writer.Write(baseProperties[i].Name + $"({propertyType})" + ": ");
                string productInfo = this.reader.ReadLine();
                productData.Add(productInfo);
                this.writer.WriteLine(new string(Constants.HorizontalLine, baseProperties[i].Name.Length + propertyType.Length + productInfo.Length + 4) + Constants.BottomRightAngle);
            }

            for (int i = 0; i < currentClassProperties.Length; i++)
            {
                string propertyType = currentClassProperties[i].PropertyType.Name;
                this.writer.Write(currentClassProperties[i].Name + $"({propertyType})" + ": ");
                string productInfo = this.reader.ReadLine();
                productData.Add(productInfo);
                this.writer.WriteLine(new string(Constants.HorizontalLine, currentClassProperties[i].Name.Length + propertyType.Length + productInfo.Length + 4) + Constants.BottomRightAngle);
            }

            return productData;
        }
    }
}