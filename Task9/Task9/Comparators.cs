using System;
namespace Task9
{
    public static class Comparators
    {
        public static bool CompareByName(object name, Product prod)
        {
                
            return prod.Name == name.ToString();
        }
        public static bool CompareByPrice(object price, Product prod)
        {
            if (!(price is double))
                throw new InvalidCastException();
            return prod.Price == (double)price;
        }
        public static bool CompareByWeight(object weight, Product prod)
        {
            if (!(weight is double))
                throw new InvalidCastException();
            return prod.Price == (double)weight;
        }

        public static bool IsNotSpoiled(object date, Product prod)
        {
            if (!(date is DateTime))
                throw new InvalidCastException();
            TimeSpan time = (DateTime)date - prod.Date;
            return time.Days < prod.ExpirationInDays;
        }
        public static bool IsSpoiled(object date, Product prod)
        {
            if (!(date is DateTime))
                throw new InvalidCastException();
            TimeSpan time = (DateTime)date - prod.Date;
            return time.Days > prod.ExpirationInDays;
        }
    }
}
