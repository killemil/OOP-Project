namespace GreatWall.Client.Factory
{
    using System.Collections.Generic;
    using GreatWall.Entities.Entities.TechProducts.Audio;
    using GreatWall.Entities.Entities.TechProducts.Cameras;
    using GreatWall.Entities.Entities.TechProducts.Computers;
    using GreatWall.Entities.Entities.TechProducts.Phones;
    using GreatWall.Entities.Entities.TechProducts.TVs;
    using GreatWall.Entities.Enumerations;
    using GreatWall.Entities.Interfaces;

    public class ProductFactory
    {
        public IProduct CreateProduct(Category category, SubCategory subCategory, IList<string> data)
        {
            string model = data[0];
            string manufacturer = data[1];
            int quantity = int.Parse(data[2]);
            decimal price = decimal.Parse(data[3]);
            string color = data[4];
            double weight = double.Parse(data[5]);
            string size = data[6];

            switch (subCategory.ToString())
            {
                case "Processors":
                    return new Processor(manufacturer, quantity, price, color, model, data[6], int.Parse(data[7]), weight, size, category, subCategory);
                case "Motherboards":
                    return new Motherboard(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], int.Parse(data[9]));
                case "Batteries":
                    return new Battery(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8]);
                case "Displays":
                    return new Display(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], bool.Parse(data[8]), data[9], data[10], data[11]);
                case "GraphicCards":
                    return new GraphicCard(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9]);
                case "HardDrives":
                    return new HardDrive(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], double.Parse(data[10]), double.Parse(data[11]));
                case "Laptops":
                    return new Laptop(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], data[10], data[11], data[12], data[13], data[14]);
                case "Memories":
                    return new Memory(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9]);
                case "PCs":
                    return new PC(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], data[10], data[11], data[12], data[13], data[14]);
                case "PowerSupplies":
                    return new PowerSupply(manufacturer, quantity, price, color, model, weight, size, category, subCategory, int.Parse(data[7]));
                case "Amplifiers":
                    return new Amplifier(model, manufacturer, quantity, price, color, weight, size, category, subCategory, int.Parse(data[7]), data[8], bool.Parse(data[9]), bool.Parse(data[10]));
                case "Headphones":
                    return new Headphone(model, manufacturer, quantity, price, color, weight, size, category, subCategory, int.Parse(data[7]), int.Parse(data[8]), bool.Parse(data[9]), double.Parse(data[10]));
                case "MediaPlayers":
                    return new MediaPlayer(model, manufacturer, quantity, price, color, weight, size, data[7], int.Parse(data[8]), data[9], bool.Parse(data[10]), category, subCategory);
                case "Speakers":
                    return new Speaker(model, manufacturer, quantity, price, color, weight, size, category, subCategory, int.Parse(data[7]), data[8], int.Parse(data[9]));
                case "PhotographicCameras":
                    return new PhotographicCamera(data[7], data[8], data[9], data[10], data[11], data[12], data[13], manufacturer, quantity, price, color, model, weight, size, category, subCategory);
                case "VideoCameras":
                    return new VideoCamera(data[7], data[8], data[9], data[10], data[11], data[12], data[13], manufacturer, quantity, price, color, model, weight, size, category, subCategory);
                case "Phones":
                    return new Phone(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], int.Parse(data[10]));
                case "SmartPhones":
                    return new SmartPhone(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], int.Parse(data[10]), data[11], data[12], data[13], data[14], data[15], data[16]);
                case "SmartTVs":
                    return new SmartTV(manufacturer, quantity, price, color, model, weight, size, category, subCategory, bool.Parse(data[7]), data[8], data[9], data[10], data[11], int.Parse(data[12]));
                case "TVs":
                    return new TV(manufacturer, quantity, price, color, model, weight, size, category, subCategory, data[7], data[8], data[9], int.Parse(data[10]));
                default:
                    return null;
            }
        }
    }
}
