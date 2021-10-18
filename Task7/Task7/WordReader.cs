using System;
namespace Task7
{
    public class WordReader:IWordReader
    {Не потрібний конструктор
        public WordReader()
        {
        }

        public string GetWord()
        {А якщо користувач не введе слово, а просто натисне ввід?
            return Console.ReadLine();
        }

        public void ShowWord(string s)
        {
            Console.WriteLine("Enter an equivalent of the {0}", s);
        }
    }
}
