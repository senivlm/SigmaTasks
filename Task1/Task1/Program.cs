using System;
using System.Linq;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Buy buy1 = new Buy((new Product("Ruba", 23, 23), 1), (new Product("Salo", 245, 75), 4));
                Check.PrintCheck(buy1);
                buy1.AddProducts((new Product("Kura", 23, 4), 4), (new Product("Maslo", 34, 0.5), 2));
                Check.PrintCheck(buy1);
                buy1.DeleteProduct(new Product("Kura", 23, 4));
                Check.PrintCheck(buy1);
                
                



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            
            
            

        }
    }
}
