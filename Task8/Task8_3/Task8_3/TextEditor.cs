using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Task8_3
{
    public class TextEditor
    {
        private string[] text;



        public TextEditor(string path="")
        {
            if (path!="")
            {
                try
                {
                    ReadFromFile(path);

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        public void ReadFromFile(string path)
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

        public string FindBiggestAttachment()
        {
            if (text!=null)
            {
                List<(int, int, int,int,int)> list = new List<(int,int,int,int,int)>();
                int sentenceEndIndex=0,sentenceStartIndex=0;
                int stringEndIndex=0, stringStartIndex=0;
                int closingBracketIndex = 0;
                int closingBracketStringIndex=0;
                int currentStringIndex=0;
                int currentBracketIndex=0;
                int counter=0;
                while(true)
                {
                    while (true)
                    {
                        if (stringEndIndex >= text.Length)
                            break;
                        sentenceEndIndex = text[stringEndIndex].IndexOf(".",sentenceEndIndex);
                        if (sentenceEndIndex != -1)
                            break;
                        ++stringEndIndex;
                        sentenceEndIndex = 0;
                    }
                    if (stringEndIndex >= text.Length)
                        break;
                    
                    closingBracketIndex = sentenceStartIndex;
                    closingBracketStringIndex = stringStartIndex;
                    while ( closingBracketStringIndex <= stringEndIndex)
                    {
                        if (closingBracketStringIndex == stringEndIndex)
                            if (closingBracketIndex >= sentenceEndIndex)
                                break;
                        closingBracketIndex = text[closingBracketStringIndex].IndexOf(")", closingBracketIndex);
                        if (closingBracketIndex == -1)
                        {
                            ++closingBracketStringIndex;
                            closingBracketIndex = 0;
                            continue;
                        }
                        else
                        {
                            
                            currentStringIndex = stringStartIndex;
                            currentBracketIndex = sentenceStartIndex;
                            int temp = 0;
                            while ( currentStringIndex <= closingBracketStringIndex)
                            {
                                
                                if (currentStringIndex == closingBracketStringIndex)
                                    if (currentBracketIndex >= closingBracketIndex)
                                        break;
                                currentBracketIndex = text[currentStringIndex].IndexOf("(", currentBracketIndex);
                                if (currentBracketIndex == -1)
                                {
                                    ++currentStringIndex;
                                    currentBracketIndex = 0;
                                    continue;
                                }
                                if ( currentStringIndex <= closingBracketIndex)
                                {
                                    
                                    if (currentStringIndex == closingBracketIndex)
                                    {
                                        if (currentBracketIndex < closingBracketIndex)
                                            ++temp;
                                    }
                                    else
                                    {
                                        ++temp;
                                        ++currentBracketIndex;
                                    }
                                    
                                }
                            }
                            currentStringIndex = stringStartIndex;
                            currentBracketIndex = sentenceStartIndex;
                            while (currentStringIndex <= closingBracketStringIndex)
                            {
                                
                                if (currentStringIndex == closingBracketStringIndex)
                                    if (currentBracketIndex >= closingBracketIndex)
                                        break;
                                currentBracketIndex = text[currentStringIndex].IndexOf(")", currentBracketIndex);
                                if (currentBracketIndex == -1)
                                {
                                    ++currentStringIndex;
                                    currentBracketIndex = 0;
                                    continue;
                                }
                                if (currentStringIndex <= closingBracketIndex)
                                {
                                    
                                    if (currentStringIndex == closingBracketIndex)
                                    {
                                        if (currentBracketIndex < closingBracketIndex)
                                            ++temp;
                                    }
                                    else
                                    {
                                        --temp;
                                        ++currentBracketIndex;
                                    }
                                }
                            }
                            if (temp > counter)
                                counter = temp;

                        }
                        if (++closingBracketIndex >= text[closingBracketStringIndex].Length)
                        {
                            closingBracketStringIndex++;
                            closingBracketIndex = 0;
                        }
                    }
                    list.Add((counter, stringStartIndex, sentenceStartIndex, stringEndIndex, sentenceEndIndex));
                    counter = 0;
                    if (++sentenceEndIndex >= text[stringEndIndex].Length)
                    {
                        stringStartIndex = ++stringEndIndex;
                        sentenceStartIndex = sentenceEndIndex = 0;
                    }
                    else
                    {
                        stringStartIndex = stringEndIndex;
                        sentenceStartIndex = sentenceEndIndex;
                    } 
                }
                int max=0;
                int index=0,count=0;
                foreach (var item in list)
                {
                    if (max < item.Item1)
                    {
                        max = item.Item1;
                        index = count;
                    }
                    count++;    

                }
                StringBuilder result = new StringBuilder();
                for (int i = list[index].Item2; i <= list[index].Item4; i++)
                {
                    if (i == list[index].Item2)
                    {
                        if (i == list[index].Item4)
                            result.Append(text[i].Substring(list[index].Item3, list[i].Item5 - list[i].Item3));
                        else
                            result.Append(text[i].Substring(list[index].Item3));
                    }
                    else
                    {
                        if (i != list[index].Item4)
                            result.Append(text[i].Substring(0));
                        else
                            result.Append(text[i].Substring(0, list[index].Item5-1));
                    }
                        
                }

                return result.ToString();
            }

            return "";
        }
    }
}
