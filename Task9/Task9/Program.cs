using System;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            Check.DeleteSpoiledEvent += StorageEventMethodHandler.DeleteSpoiledProducts;

            storage.LogEvent += StorageEventMethodHandler.LogToFile;
            storage.ReplaceEvent += StorageEventMethodHandler.ReplaceProduct;
            storage.AddProductFromFile(@"/Users/artemhuk/Desktop/data.txt", @"/Users/artemhuk/Desktop/LogFile.txt");
            Check.Print(storage, @"/Users/artemhuk/Desktop/LogFile.txt");
            var temp=storage.FindByAttribute("DairyProduct", Comparators.CompareByName);
            Console.WriteLine(storage);
        }
    }
}
