using System;
using System.Linq;
namespace Task9
{
    public class Meat : Product
    {

        public enum Category
        {
            Premium,
            I,
            II
        }
        public enum Type
        {
            Mutton,
            Veal,
            Pork,
            Chicken
        }
        public Category MeatCategory { get; private set; }
        public Type MeatType { get; private set; }
        protected static class MeatPriceChangePercentage
        {
            public const double premiumPercentage = 0.1;
            public const double IPercentage = 0.06;
            public const double IIPercentage = 0.03;

        }

        public override void ChangePrice(double percentage)
        {

            switch (MeatCategory)
            {
                case Category.Premium:
                    price = price + price * MeatPriceChangePercentage.premiumPercentage * percentage;
                    break;
                case Category.I:
                    price = price + price * MeatPriceChangePercentage.IPercentage * percentage;
                    break;
                default:
                    price = price + price * MeatPriceChangePercentage.IIPercentage * percentage;
                    break;
            }



        }
        public Meat(string name, double price, double weight, DateTime date, int expirationInDays, Category category, Type type) : base(name, price, weight, date, expirationInDays)
        {
            MeatCategory = category;
            MeatType = type;

        }
        public Meat(string name, double price, double weight, Category category, Type type) : base(name, price, weight)
        {
            MeatCategory = category;
            MeatType = type;

        }
        public Meat() : this(" ", 0, 0, DateTime.Today, 0, 0, 0)
        {

        }
        public override string ToString()
        {
            return base.ToString() + ",Category: " + MeatCategory + ",Type: " + MeatType;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            return true;
        }
        public override void Parse(string s)
        {
            try
            {
                string[] sArray = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] sArray2 = new string[5];
                Array.Copy(sArray, sArray2, 5);
                base.Parse(string.Join(" ", sArray2));
                if (!Enum.TryParse(typeof(Category), sArray[5], out object category))
                    throw new FormatException("Meat category format exception");
                MeatCategory = (Category)category;
                if (!Enum.TryParse(typeof(Type), sArray[6], out object type))
                    throw new FormatException("Meat type format exception");
                MeatType = (Type)type;
            }
            catch (FormatException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

    }
}
