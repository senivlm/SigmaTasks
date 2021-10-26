using System;

namespace Task9
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
                    throw new FormatException("Incorect input.");
                Name = sArray[0];
                if (!double.TryParse(sArray[1], out double price))
                    throw new FormatException("Price format exception");
                Price = price;
                if (!double.TryParse(sArray[2], out double weigth))
                    throw new FormatException("Weight format exception");
                Weight = weigth;
                string[] sDate = sArray[3].Split(".", StringSplitOptions.RemoveEmptyEntries);
                if (sDate.Length != 3)
                    throw new FormatException("Date format exception");
                int[] aDate = new int[3];
                for (int i = 0; i < aDate.Length; i++)
                {
                    if (!int.TryParse(sDate[i], out aDate[i]))
                        switch (i)
                        {
                            case 0:
                                throw new FormatException("Day format exception");
                                
                            case 1:
                                throw new FormatException("Month format exception");   
                            default:
                                throw new FormatException("Year format exception");
                        }                    
                }
                Date = new DateTime(aDate[2], aDate[1], aDate[0]);
                if (!int.TryParse(sArray[4], out int expirationInDays))
                    throw new FormatException("Expiration in days format exception");
                ExpirationInDays = expirationInDays;


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
