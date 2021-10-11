using System;
using System.Collections.Generic;
    
namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Polynomial p = new Polynomial((0, 2.3), (2, 2.34), (3, 2.42), (4, 2.45), (5, 2.457));
                Console.WriteLine(p);
                Polynomial p2 = new Polynomial();
                p2.Parse("1.56+2x^1+ (-3x)^2 + 4x^7");
                Console.WriteLine(p2);
                Console.WriteLine("Add");
                Console.WriteLine(p+p2);
                Console.WriteLine("Subtract");
                Console.WriteLine(p-p2);
                Console.WriteLine("Multiply");
                Console.WriteLine(p*p2);
                Polynomial p3 = 12.3;
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }
    }
}
