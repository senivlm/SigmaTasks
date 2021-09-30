using System;
namespace Task2
{
    public class DairyProducts: Product
    {
        protected int expirationDate;
        public int ExpirationDate
        {
            private set
            {
                if (value>=0)
                {
                    expirationDate = value;
                }
            }
            get
            {
                return expirationDate;
            }
        }
        protected const double dairyProductPriceChangePercentage = 0.005;
        public DairyProducts(string name,double price,double weight,int expirationDate):base(name,price,weight)
        {
            this.ExpirationDate = expirationDate;
        }
        public DairyProducts():this(null,0,0,0)
        {

        }
        public override void ChangePrice(double percentage)
        {
            price = price + price * dairyProductPriceChangePercentage * ExpirationDate*percentage;
        }
        public override string ToString()
        {
            return base.ToString()+",Expiration date: "+ExpirationDate;
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            DairyProducts temp = obj as DairyProducts;
            if (temp != null)
            {
                if (temp.Name == this.Name && temp.Price == this.Price && temp.Weight == this.Weight && temp.ExpirationDate==this.expirationDate )
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
