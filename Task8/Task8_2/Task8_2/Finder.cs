using System;
using System.Collections.Generic;
namespace Task8_2
{
    public class Finder
    {
        

        public static Storage FindEqual(Storage s1,Storage s2, CompareDelegate compare)
        {
            List<Product> temp = new List<Product>();
            foreach (Product item1 in s1)
            {
                foreach (Product item2 in s2)
                {
                    if (compare?.Invoke(item1,item2) == 1)
                        temp.Add(item1);
                }
            }
            
            return new Storage(temp);
        }

        public static Storage FindUnequal(Storage s1, Storage s2, CompareDelegate compare)
        {
            List<Product> temp = new List<Product>();
            bool flag = true;
            foreach (Product item1 in s1)
            {
                foreach (Product item2 in s2)
                {
                    if (compare?.Invoke(item1, item2) == 1)
                        flag = false;
                }
                if (flag)
                    temp.Add(item1);
                flag = true;
            }

            return new Storage(temp);
        }

        public static Storage FindUnique(Storage s, CompareDelegate compare)
        {
            List<Product> temp = new List<Product>();
            bool flag = true;
            for (int i = 0; i < s.Size; i++)
            {
                for (int j = 0; j < s.Size; j++)
                {
                    if(i!=j)
                        if (compare?.Invoke(s[i],s[j]) == 1)
                            flag = false;
                }
                if (flag)
                    temp.Add(s[i]);
                flag = true;
            }
            return new Storage(temp);
        }


    }
}
