using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int size;
                Console.WriteLine("Enter size of storage");
                if (!int.TryParse(Console.ReadLine(), out size))
                {

                    throw new FormatException("Wrong input");
                }

                Storage st = new Storage(size);
                st.InitStorage();
                Console.WriteLine(st);
                var st2 = st.FindAllMeat();
                st.ChangeAllPrice(0.3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            

            
           
            
        }
    }
}
