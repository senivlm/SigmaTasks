using System;

namespace Task6._2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StatisticsHandler s = new StatisticsHandler(@"/Users/artemhuk/Desktop/Data3.txt");
                Console.WriteLine(s);
                foreach (var item in s.NumberOfVisits())
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
                foreach (var item in s.MostPopularDay())
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
                foreach (var item in s.MostPopularTime())
                {
                    Console.WriteLine(item.Key + " " + item.Value.Item1 + " " + item.Value.Item2);
                }
                var popular = s.MostPopularTimeForWeak();
                Console.WriteLine(popular.Item1 + " " + popular.Item2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
