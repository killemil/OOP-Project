namespace GreatWall.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using GreatWall.Client.StaticData;
    using GreatWall.Entities.Interfaces.Console;
    using GreatWall.Entities.Interfaces.DataCollector;

    public class DataCollector : ICollector
    {
        public DataCollector(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }

        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public IList<string> GetProductData(string currentCategoryStr, string currentSubCategoryStr)
        {
            string className = string.Empty;
            if (currentSubCategoryStr.EndsWith("ies"))
            {
                className = currentSubCategoryStr.Substring(0, currentSubCategoryStr.Length - 3) + "y";
            }
            else
            {
                className = currentSubCategoryStr.Substring(0, currentSubCategoryStr.Length - 1);
            }

            Type currentClass = Type.GetType(Constants.ClassesNamespace + currentCategoryStr + "." + className + Constants.AssemblyName);
            PropertyInfo[] baseProperties = currentClass.BaseType.GetProperties();
            PropertyInfo[] currentClassProperties = currentClass.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            IList<string> productData = new List<string>();
            for (int i = 0; i < baseProperties.Length - 2; i++)
            {
                string propertyType = baseProperties[i].PropertyType.Name;
                this.Writer.Write(baseProperties[i].Name + $"({propertyType})" + ": ");
                string productInfo = this.Reader.ReadLine();
                productData.Add(productInfo);
                this.Writer.WriteLine(new string(Constants.HorizontalLine, baseProperties[i].Name.Length + propertyType.Length + productInfo.Length + 4) + Constants.BottomRightAngle);
            }

            for (int i = 0; i < currentClassProperties.Length; i++)
            {
                string propertyType = currentClassProperties[i].PropertyType.Name;
                this.Writer.Write(currentClassProperties[i].Name + $"({propertyType})" + ": ");
                string productInfo = this.Reader.ReadLine();
                productData.Add(productInfo);
                this.Writer.WriteLine(new string(Constants.HorizontalLine, currentClassProperties[i].Name.Length + propertyType.Length + productInfo.Length + 4) + Constants.BottomRightAngle);
            }

            return productData;
        }

        public IList<string> GetCustomerDetails()
        {
            IList<string> customerDetails = new List<string>();
            this.Writer.Write("Enter name: ");
            customerDetails.Add(this.Reader.ReadLine());
            this.Writer.Write("Enter address for delivery: ");
            customerDetails.Add(this.Reader.ReadLine());
            this.Writer.Write("Telephone number: ");
            customerDetails.Add(this.Reader.ReadLine());
            this.Writer.Write("Number of products: ");
            customerDetails.Add(this.Reader.ReadLine());

            return customerDetails;
        }

        public IList<string> GetLoginDetails()
        {
            IList<string> result = new List<string>();

            this.Writer.Write("Enter Username: ");
            result.Add(this.Reader.ReadLine().Trim());
            this.Writer.Write("Enter Password: ");
            result.Add(this.Reader.ReadLine().Trim());

            return result;
        }
    }
}
