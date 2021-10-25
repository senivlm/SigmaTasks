using System;

namespace Task8_2
{
    public class Product
    {
        protected string name;
        protected double price;
        protected double weight;
        public DateTime Date { get; set; }
        protected int expirationInDays;

        public int ExpirationInDays
        {
            get => expirationInDays;
            set
            {
                if (value < 0)
                    throw new FormatException("Expiration date cannot be negative");
                expirationInDays = value;
            }
        }
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
                    throw new FormatException("Wrong input Name");
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
        public Product(string name, double price, double weight, DateTime date, int expirationInDays) : this(name, price, weight)
        {

            this.Date = date;
            ExpirationInDays = expirationInDays;

        }
        public Product() : this(" ", 0, 0, DateTime.Today, 0)
        {

        }

        public virtual void ChangePrice(double percentage)
        {
            price = price - price * priceChangePercentage;
        }
        public override string ToString()
        {
            return string.Format($"Name: {name} Weight: {weight} kg ,Price: {price} UAH Term: {Date}");
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            
            if (this.GetType() != obj.GetType()) return false;
            
            return true;
            
        }

        


        public virtual void Parse(string s)
        {

            try
            {

                if (s == null)
                    throw new NullReferenceException("String is empty");
                string[] sArray = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (sArray.Length != 5)
                    throw new FormatException("Incorect input. \"s\" has to contain name,price,weigt,date,expiration date");
                Name = sArray[0];
                Price = double.Parse(sArray[1]);

                Weight = double.Parse(sArray[2]);
                string[] sDate = sArray[3].Split(".", StringSplitOptions.RemoveEmptyEntries);
                if (sDate.Length != 3)
                    throw new FormatException("Icorect date format Corect: dd.mm.yyyy");
                int[] aDate = new int[3];
                for (int i = 0; i < aDate.Length; i++)
                {
                    aDate[i] = int.Parse(sDate[i]);
                }
                Date = new DateTime(aDate[2], aDate[1], aDate[0]);
                ExpirationInDays = int.Parse(sArray[4]);
            }
            catch (FormatException ex)
            {
                throw;
            }
            catch (NullReferenceException ex)
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
