using System;
using System.IO;
using System.Text;

namespace Practice
{
    public class TextEditor
    {

        private string[] text;




        public TextEditor(string path)
        {
            try
            {
                ReadFile(path);
            }
            catch (Exception ex)
            {
                throw;
            }   
        }

        public TextEditor()
        {

        }

        public void ReadFile(string path)
        {
            try
            {
                text=File.ReadAllLines(path);

            }
            catch (Exception ex)
            {
                throw;
            }
            
            
        }

        public void ChangeSymbols(string symbol,string newSymbol1,string newSymbol2)
        {
            StringBuilder[] tempText = new StringBuilder[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                tempText[i] = new StringBuilder(text[i]);   
            }
            
            int start = 0,end=tempText.Length-1,posS=0,posE=0;
            try
            {
                while (start <=  end )
                {
                    while (start<text.Length)
                    {
                        posS = tempText[start].ToString().IndexOf(symbol);
                        if (posS != -1)
                        {
                            tempText[start] = tempText[start].Remove(posS, symbol.Length).Insert(posS, newSymbol1);
                            break;
                        }   
                        else
                            start++;
                    }
                    while (end>=0)
                    {
                        posE = tempText[end].ToString().LastIndexOf(symbol);
                        if (posE != -1)
                        {
                            tempText[end] = tempText[end].Remove(posE, symbol.Length).Insert(posE, newSymbol2);
                            break;
                        }    
                        else
                            end--;
                    }   
                }
                for (int i = 0; i < tempText.Length; i++)
                {
                    text[i] = tempText[i].ToString();
                }
            }
            catch (Exception ex){ throw; }            
        }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    temp.Append(text[i] + "\n");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
            return temp.ToString(); 
        }
        
    }
}
