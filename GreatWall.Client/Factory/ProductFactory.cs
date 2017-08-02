namespace GreatWall.Client.Factory
{
    using GreatWall.Entities.Entities.TechProducts.Computers;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;
    using System;
    using System.Collections.Generic;

    public static class ProductFactory
    {
        public static IProduct GetProduct(Category category, SubCategory subCategory, IList<string> data)
        {
            switch (subCategory.ToString())
            {
                case "Processors":
                    return new Processor(data[3], int.Parse(data[4]), decimal.Parse(data[5]), data[6], data[2], data[0], int.Parse(data[1]), double.Parse(data[7]), data[8], category, subCategory);
                default:
                    return null;
            }
        }
    }
}
