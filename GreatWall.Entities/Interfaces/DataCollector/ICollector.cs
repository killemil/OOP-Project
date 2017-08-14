namespace GreatWall.Entities.Interfaces.DataCollector
{
    using System.Collections.Generic;

    public interface ICollector
    {
        IList<string> GetProductDetails(string category, string subCategory);

        IList<string> GetCustomerDetails();

        IList<string> GetLoginDetails();
    }
}
