using System;
namespace Task7
{
    public class WordReader:IWordReader
    {
        public WordReader()
        {
        }

        public string GetWord()
        {
            return Console.ReadLine();
        }

        public void ShowWord(string s)
        {
            Console.WriteLine("Enter an equivalent of the {0}", s);
        }
    }
}
