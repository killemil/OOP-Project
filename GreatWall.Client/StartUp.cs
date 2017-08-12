namespace GreatWall.Client
{
    using GreatWall.Client.Core;
    using GreatWall.Client.Factory;
    using GreatWall.Client.Repositories;
    using GreatWall.Client.SeedData;
    using GreatWall.Entities.Entities.Console;
    using GreatWall.Entities.Interfaces.Console;
    using GreatWall.Entities.Interfaces.DataCollector;
    using GreatWall.Entities.Interfaces.Repository;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IColor color = new ConsoleColour();
            ICursor cursor = new ConsoleCursor();

            ProductsSeeder productSeeder = new ProductsSeeder();
            CustomerSeeder customersSeeder = new CustomerSeeder();

            ProductFactory productFactory = new ProductFactory();
            CustomerFactory customerFactory = new CustomerFactory();

            IRepository productRepo = new ProductsRepository(productFactory, customerFactory, productSeeder, customersSeeder);
            ICollector collector = new DataCollector(reader, writer);
            Engine engine = new Engine(productRepo, collector, writer, color, cursor);
            engine.Run();
        }
    }
}
