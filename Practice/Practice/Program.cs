using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor txt = new TextEditor(@"/Users/artemhuk/Desktop/Data2.txt");
            Projection p = new Projection(3, 3, 3);
            p.Init3dMatrix();
            txt.ChangeSymbols("#","<",">");
            p.Create2dImage();
            MyFile f = new MyFile(@"c: \ WebServers \ home \ testsite \ www \ file.myfile.txt");
            Console.WriteLine(f.GetRootFolderName());
        }
    }
}
