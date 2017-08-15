namespace GreatWall.Client
{
    using GreatWall.Client.Core;
    using GreatWall.Client.Factory;
    using GreatWall.Client.Repositories;
    using GreatWall.Client.SeedData;
    using GreatWall.Entities.Entities.Console;
    using GreatWall.Entities.Interfaces.Console;
    using GreatWall.Entities.Interfaces.DataCollector;
    using GreatWall.Entities.Interfaces.Engine;
    using GreatWall.Entities.Interfaces.Repository;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IConsoleManipulator consoleManipulator = new ConsoleManipulator();

            ProductsSeeder productSeeder = new ProductsSeeder();
            CustomerSeeder customersSeeder = new CustomerSeeder();

            ProductFactory productFactory = new ProductFactory();
            CustomerFactory customerFactory = new CustomerFactory();

            IRepository productRepo = new ProductsRepository(productFactory, customerFactory, productSeeder, customersSeeder);
            ICollector collector = new DataCollector(reader, writer);
            IEngine engine = new Engine(productRepo, collector, writer, consoleManipulator);
            engine.Run();
        }
    }
}
