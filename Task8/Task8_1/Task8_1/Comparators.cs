using System;
namespace Task8_1
{
    public static class Comparators
    {
        public static int CompareProductByPrice(object o1, object o2)
        {
            try
            {
                (Product, Product) products = Cast.CastToProduct(o1, o2);
                return products.Item1.Price.CompareTo(products.Item2.Price);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int CompareProductByName(object o1, object o2)
        {
            try
            {
                (Product, Product) products = Cast.CastToProduct(o1, o2);
                return products.Item1.Name.CompareTo(products.Item2.Name);
            }
            catch (Exception ex)
            {
                throw;
            }   
        }


        
    }

    public static class Cast
    {
        public static (Product, Product) CastToProduct(object o1, object o2)
        {
            if (o1 == null || o2 == null)
                throw new ArgumentNullException();
            Product p1 = o1 as Product;
            if (p1 == null)
                throw new InvalidCastException("o1 is not Product");
            Product p2 = o2 as Product;
            if (p2 == null)
                throw new InvalidCastException("o2 is not Product");
            return (p1, p2);
        }
    }
}
