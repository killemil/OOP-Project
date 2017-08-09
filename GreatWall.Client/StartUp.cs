namespace GreatWall.Client
{
    using GreatWall.Client.Core;
    using GreatWall.Client.Repositories;
    using GreatWall.Entities.Interfaces;
    using GreatWall.Entities.Interfaces.Customers;
    using GreatWall.Entities.Interfaces.Repository;

    public class StartUp
    {
        public static void Main()
        {
            IProductRepository<IProduct> productRepo = new ProductRepository();
            IClientRepository<ICustomer> customersRepo = new CustomerRepository();
            Engine engine = new Engine(productRepo, customersRepo);
            engine.Run();
        }
    }
}
