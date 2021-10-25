using System;

namespace Task8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage s1 = new Storage();
            s1.InitFromFile(@"/Users/artemhuk/Desktop/data.txt");
            Storage s2 = new Storage();
            CompareDelegate c1 = new CompareDelegate(Comparators.CompareName);
            s2.InitFromFile(@"/Users/artemhuk/Desktop/dataS2.txt");
            var s3 = Finder.FindEqual(s1, s2, Comparators.Compare);
            var s4 = Finder.FindUnequal(s1, s2, c1);
            Console.WriteLine(s3);
            Console.WriteLine();
            Console.WriteLine(s4);
            Console.WriteLine();

            Console.WriteLine(Finder.FindUnique(s1,Comparators.CompareName));



        }
    }
}
