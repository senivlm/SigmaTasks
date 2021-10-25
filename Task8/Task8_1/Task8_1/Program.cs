using System;
using System.Collections.Generic;

namespace Task8_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            try
            {
                List<Product> ls = new List<Product> { new Product("Name1", 10, 20), new Product("Name2", 3, 20), new Product("Name3", 13, 20), new Product("Name4", 7, 20) };
                foreach (var item in ls)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Product[] temp = ls.ToArray();

                Sorter.BubbleSort(temp, Comparators.CompareProductByPrice);
                foreach (var item in temp)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();

                Sorter.BubbleSort(temp, Comparators.CompareProductByName);
                foreach (var item in temp)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
              
        }
    }
}
