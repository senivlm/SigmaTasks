using System;
using System.IO;
namespace Task9
{
    public static class StorageEventMethodHandler
    {
        public static void LogToFile(string logPath,string exception,string incorrectLine)
        {
            using (StreamWriter file = new StreamWriter(logPath,true))
            {
                file.WriteLine(DateTime.Now+"\n");
                file.WriteLine(exception);
                file.WriteLine("\nIncorrect line\n"+incorrectLine);
            }
        }

        public static void ReplaceProduct(Storage storage,string incorrectLine)
        {
            Console.WriteLine("Incorect line: " + incorrectLine+"\n");
            Console.WriteLine("Enter product type: p(product)/ m(meat)/ d(dairy product)");
            string productType;
            bool flag=true;
            while (flag)
            {
                (string, double, double, DateTime, int) temp;
                productType = Console.ReadLine();
                switch (productType)
                {
                    case "p":

                        temp = EnterProduct();
                        storage.AddProduct(new Product(temp.Item1,temp.Item2,temp.Item3,temp.Item4,temp.Item5));
                        flag = false;
                        break;
                    case "m":
                        temp = EnterProduct();
                        Console.WriteLine("\nEnter meat category");
                        object categor;
                        while (!Enum.TryParse(typeof(Meat.Category), Console.ReadLine(), out categor))
                        {
                            Console.WriteLine("\nEnter meat category");
                        }

                        Console.WriteLine("\nEnter meat category");
                        object type;
                        while (!Enum.TryParse(typeof(Meat.Type), Console.ReadLine(), out  type))
                        {
                            Console.WriteLine("\nEnter meat type");
                        }
                        storage.AddProduct(new Meat(temp.Item1, temp.Item2, temp.Item3, temp.Item4, temp.Item5,(Meat.Category)categor,(Meat.Type)type));
                        flag = false;
                        break;
                    case "d":
                        temp = EnterProduct();
                        storage.AddProduct(new DairyProducts(temp.Item1, temp.Item2, temp.Item3, temp.Item4, temp.Item5));
                        flag = false;
                        break;
                    default:
                        break;
                }
            }

        }

        private static (string, double, double, DateTime, int) EnterProduct()
        {
            Console.WriteLine("\nEnter name");
            string name = Console.ReadLine();
            Console.WriteLine("\nEnter price");
            double price = 0;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("\nEnter price");
            }

            Console.WriteLine("\nEnter weight");
            double weight = 0;
            while (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("\nEnter weight");
            }

            Console.WriteLine("\nEnter date");
            DateTime date = new DateTime();
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("\nEnter date");
            }

            Console.WriteLine("\nEnter expiration in days");
            int expirationInDays=0;
            while (!int.TryParse(Console.ReadLine(), out expirationInDays))
            {
                Console.WriteLine("\nEnter date");
            }
            return (name, price, weight, date, expirationInDays);
        }

        public static void DeleteSpoiledProducts(Storage storage,string path)
        {
            var temp=storage.FindByAttribute(DateTime.Now, Comparators.IsSpoiled);
            using (StreamWriter file = new StreamWriter(path))
            {
                foreach (var item in temp)
                {
                    file.WriteLine(item);
                }
            }
            temp = storage.FindByAttribute(DateTime.Now, Comparators.IsNotSpoiled);
            storage.DeleteAllProduct();
            foreach (var item in temp)
            {
                storage.AddProduct(item);
            }

        }
    }
}
