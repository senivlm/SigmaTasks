using System;
using System.Linq;
using System.Collections.Generic;
namespace Task1
{
    public class Buy
    {
        public List<(Product, int)> prods;
        public int TotalAmount { get; private set; }
        public double TotalPrice { get;private set; }
        public double TotalWeight { get; private set; }

        
        private void CountTotalPriceWeightAmount()
        {
            this.TotalPrice = 0;
            this.TotalWeight = 0;
            this.TotalAmount = 0;
            if (prods != null)
            {
                foreach ((Product, int) item in prods)
                {
                    if (item.Item1 != null)
                    {
                        this.TotalAmount += item.Item2;
                        this.TotalPrice += item.Item1.Price * item.Item2;
                        this.TotalWeight += item.Item1.Weight * item.Item2;
                    }
                    else
                        throw new ArgumentNullException("Incorect input");
                    
                }
            }

            
        }
        public Buy()
        {
            this.prods = new List<(Product, int)>();
            CountTotalPriceWeightAmount();

        }
        public Buy(params (Product product,int amount)[] prods)
        {
            if (prods != null)
            {

                this.prods = new List<(Product, int)>();
                foreach ((Product, int) item in prods)
                {
                    if (item.Item1 != null)
                    {
                        this.prods.Add(item);
                    }
                    else
                        throw new ArgumentNullException("Incorect input");

                }
                CountTotalPriceWeightAmount();
            }
            else
                throw new ArgumentNullException("Incorect input");
 
        }
        public void AddProducts(params (Product product,int amount)[] newProds)
        {
            if (newProds != null)
            {
                foreach ((Product, int) item in newProds)
                {
                    if (item.Item1 != null)
                    {
                        prods.Add(item);
                    }
                    else
                        throw new ArgumentNullException("Incorect input");

                }
                CountTotalPriceWeightAmount();
            }
            else
                throw new ArgumentNullException("Incorect input");
   
        }
        public void DeleteProduct(Product prod)
        {
            prods = prods.Where(x => !x.Item1.Equals(prod)).ToList();
            CountTotalPriceWeightAmount();
        }
        
        public (Product product, int amount) this[int index]
        {
            get
            {
                return prods[index];
            }

        }
        public override string ToString()
        {
            string temp = "";
            foreach ((Product,int) item in prods)
            {
                temp += item.Item1.ToString() + " Amount: " + item.Item2+"\n";
            }
            temp += "Total price: " + TotalPrice + " UAH Total weight: " + TotalWeight + " kg Total amount: " + TotalAmount + "\n";
            return temp;
        }


    }
}
