using System;
namespace Task2
{
    public class DairyProducts: Product
    {
        
        protected const double dairyProductPriceChangePercentage = 0.005;
        public DairyProducts(string name,double price,double weight,DateTime date,int expirationDays):base(name,price,weight,date,expirationDays)
        {
            
        }
        public DairyProducts(string name, double price, double weight, int expirationDays) : base(name, price, weight)
        {
            this.expirationInDays = expirationDays;
        }
        public DairyProducts():this(" ",0,0,DateTime.Today,0)
        {

        }
        public override void ChangePrice(double percentage)
        {
            price = price + price * dairyProductPriceChangePercentage * expirationInDays*percentage;
        }
        public override string ToString()
        {
            return base.ToString()+",Expiration date: "+expirationInDays;
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            DairyProducts temp = obj as DairyProducts;
            if (temp != null)
            {
                if (temp.Name == this.Name && temp.Price == this.Price && temp.Weight == this.Weight && temp.expirationInDays==this.expirationInDays )
                {
                    res = true;
                }
            }
            return res;
        }
        public override void Parse(string s)
        {
            base.Parse(s);
        }


    }
}
