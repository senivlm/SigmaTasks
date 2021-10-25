using System;
namespace Task8_2
{
    public static class Comparators
    {
        public static int  CompareName(Product p1,Product p2)
        {
            int result = 0;
            if ( p1.Name == p2.Name)
                result = 1;
            return result;
        }

        public static int Compare(Product p1, Product p2)
        {
            int result=0;
            if (!p1.Equals(p2)) return 0;
            if (p1.Name == p2.Name)
                result = 1;
            return result;
        }
    }
}
