using System;
namespace Task2
{
    public class Product
    {
        protected string name;
        protected double price;
        protected double weight;
        protected const double priceChangePercentage = 0.05;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    this.name = value;
                }
                else
                {
                    throw new FormatException("Wrong input");
                }
            }
        }
        
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new FormatException("Wrong input");
                }
            }
        }

        
        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value >= 0)
                {
                    this.weight = value;
                }
                else
                {
                    throw new FormatException("Wrong input");
                }
            }
        }

        public Product(string name, double price, double weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;

        }
        public Product() : this(" ", 0, 0)
        {

        }

        public virtual void ChangePrice(double percentage)
        {
            price= price - price * priceChangePercentage;
        }
        public override string ToString()
        {
            return "Name: " + name + ",Weight: " + weight + "kg ,Price: " + price+" UAH";
        }
        public override bool Equals(object obj)
        {
            Product temp = obj as Product;
            bool res = false;
            if (temp!=null)
            {
                if (temp.Name==this.Name)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
