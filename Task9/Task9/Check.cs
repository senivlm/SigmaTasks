using System;
namespace Task9
{
    public static class Check
    {
        public static event DeleteSpoiledProductsDelegate DeleteSpoiledEvent;

        public static void Print(Storage storage,string logPath)
        {
            DeleteSpoiledEvent.Invoke(storage,logPath);
            Console.WriteLine(storage);
        }
    }
}
