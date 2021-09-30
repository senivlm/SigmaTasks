using System;
namespace Task1
{
    public class Product
    {
        private string  name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value!=null && value.Length>0)
                {
                    this.name = value;
                }
                else
                {
                    throw new FormatException("Wrong input");
                }
            }
        }
        private double price;
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
        
        private double weight;
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
        
        public Product(string name,double price,double weight)
        {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
            
        }
        public Product():this(" ",0,0) 
        {
            
        }

        public override string ToString()
        {
            return "Name: "+name+" Price: "+price+" UAH Weight: "+weight+" kg";
        }
        public override bool Equals(object obj)
        {
            bool res = false;
            Product temp;
            if (null!=(temp=obj as Product))
            {
                if (temp.Name==this.name && temp.Price==this.Price && temp.Weight==this.weight)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
