using System;

namespace Task8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor eidtor=new TextEditor(@"/Users/artemhuk/Desktop/text.txt");
            Console.WriteLine(eidtor.FindBiggestAttachment());
        }
    }
}
