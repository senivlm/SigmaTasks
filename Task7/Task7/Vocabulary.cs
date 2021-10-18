using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Task7
{
    public class Vocabulary
    {
        //Fields
        private Dictionary<string, string> words;
        private IWordReader reader; Чому в поле заносим?



        //Constructors
        public Vocabulary(IWordReader reader,string path="")
        {
            if (reader != null)
                this.reader = reader;
            else
                throw new NullReferenceException();
            words = new Dictionary<string, string>();
            Ця конструкція не дуже надихає!
            try
            {
                if(path!="")
                    ReadFromFile(path);
            }
            catch (Exception ex)
            {
                throw;
            }      
        }


        //Methods
        public void ReadFromFile(string path)
        {
            try
            {
                string[] pairs = File.ReadAllLines(path);
                for (int i = 0; i < pairs.Length; i++)
                {
                    string[] temp;
                    temp = pairs[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (temp.Length != 2)
                        throw new FormatException();
                    if (!words.ContainsKey(temp[0]))
                        words.Add(temp[0],temp[1]);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveToFile(string path)
        {
            try
            {
                
                StreamWriter writer = new StreamWriter(path);
                foreach (KeyValuePair<string,string> word in words)
                {
                    writer.WriteLine(word.Key + " " + word.Value);
                }
                А закривати потік де будемо?
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string ChangeWords(string s)
        {
            string[] sentences = s.Split(new char[] { '.',' ',',','!','?',';',':'},StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder(s);
            for (int i = 0;i < sentences.Length; i++)
            {
                if (words.ContainsKey(sentences[i]))
                {
                    result.Replace(sentences[i], words[sentences[i]]);
                }
                else
                {
                    reader.ShowWord(sentences[i]);
                    words.Add(sentences[i], reader.GetWord());
                    result.Replace(sentences[i], words[sentences[i]]);
                }
                
            }

            return result.ToString();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in words)
            {
                result.Append(item.Key + " " + item.Value + "\n");
            }
            
            return result.ToString(); 
        }

    }

}
