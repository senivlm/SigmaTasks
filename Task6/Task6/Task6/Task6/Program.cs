using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Matrix m = new Matrix();

                m.Size = (5, 5);
                m.InitMatrix();
                Console.WriteLine(m);
                foreach (var item in m)
                {
                    Console.Write(item + " ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
