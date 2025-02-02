﻿using System;
using System.Linq;
using System.IO;
using System.Text;
namespace Task2
{
    public class Storage
    {
        private Product[] products;
        public Product this[int index]
        {
            get
            {
                if (products != null && index < products.Length)
                {
                    return products[index];
                }

                return null;
            }
            set
            {
                if (products != null && index < products.Length)
                {
                    products[index] = value;
                }

            }
        }
        public Storage(int size = 0)
        {
            if (size >= 0)
            {
                products = new Product[size];
            }
        }


        public void InitFromFile(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);
                string number = reader.ReadLine();
                int iNumber = int.Parse(number);
                products = new Product[iNumber];
                string data;

                for (int i = 0; i < iNumber; i++)
                {
                    data = reader.ReadLine();
                    string[] aData = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string[] tArray;
                    switch (aData[0])
                    {
                        case "p":
                            products[i] = new Product();
                            tArray=new string[aData.Length-1];
                            Array.Copy(aData, 1, tArray, 0, tArray.Length);
                            products[i].Parse(string.Join(" ", tArray));
                            break;
                        case "m":
                            products[i] = new Meat();
                            tArray = new string[aData.Length - 1];
                            Array.Copy(aData, 1, tArray, 0, tArray.Length);
                            products[i].Parse(string.Join(" ", tArray));
                            break;
                        case "d":
                            products[i] = new DairyProducts();
                            tArray = new string[aData.Length - 1];
                            Array.Copy(aData, 1, tArray, 0, tArray.Length);
                            products[i].Parse(string.Join(" ", tArray));
                            break;
                        default:
                            throw new FormatException("Line has to contain specifier p/m/d at the beginning");
                            break;
                    }
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw;
            }
            



        }
        public override string ToString()
        {
            string temp = "";
            if (products != null)
            {
                foreach (var item in products)
                {
                    temp = temp + item.ToString() + "\n";
                }
            }

            return temp;
        }
        private (string, double, double) ProductRead()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter price:");
            double price = 0;
            if (!double.TryParse(Console.ReadLine(), out price))
                throw new FormatException("Wrong input");
            Console.WriteLine("Enter Weight:");
            double weight = 0;
            if (!double.TryParse(Console.ReadLine(), out weight))
                throw new FormatException("Wrong input");
            return (name, price, weight);

        }
        private (string, double, double, Meat.Category, Meat.Type) MeatRead()
        {
            var item = ProductRead();
            Console.WriteLine("Enter meat category (Enter p(premium)/I/II):");
            string category = Console.ReadLine();
            Meat.Category ctgr;
            switch (category)
            {
                case "p":
                    ctgr = Meat.Category.Premium;
                    break;
                case "I":
                    ctgr = Meat.Category.I;
                    break;
                case "II":
                    ctgr = Meat.Category.II;
                    break;
                default:

                    throw new FormatException("Wrong Input");
            }
            Meat.Type tp;

            Console.WriteLine("Enter meat type (Enter m(mutton)/v(veal)/p(pork)/c(chicken)):");
            string type = Console.ReadLine();
            switch (type)
            {
                case "m":
                    tp = Meat.Type.Mutton;
                    break;
                case "v":
                    tp = Meat.Type.Veal;
                    break;
                case "p":
                    tp = Meat.Type.Pork;
                    break;
                case "c":
                    tp = Meat.Type.Chicken;
                    break;
                default:
                    throw new FormatException("Wrong input");

            }
            return (item.Item1, item.Item2, item.Item3, ctgr, tp);
        }
        private (string, double, double, int) DairyProductsRead()
        {
            var item = ProductRead();

            Console.WriteLine("Enter expiration date (date>0)");
            string sdate = Console.ReadLine();
            int date;
            int.TryParse(sdate, out date);
            return (item.Item1, item.Item2, item.Item3, date);
        }
        public void InitStorage()
        {
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine("What product do u want to add (Enter p(product)/m(meat)/d(dairy product)):");
                string type = Console.ReadLine();
                switch (type)
                {
                    case "p":
                        var item = ProductRead();
                        products[i] = new Product(item.Item1, item.Item2, item.Item3);
                        break;
                    case "m":
                        var item2 = MeatRead();
                        products[i] = new Meat(item2.Item1, item2.Item2, item2.Item3, item2.Item4, item2.Item5);
                        break;
                    case "d":
                        var item3 = DairyProductsRead();
                        products[i] = new DairyProducts(item3.Item1, item3.Item2, item3.Item3, item3.Item4);
                        break;
                    default:
                        throw new FormatException("Wrong input");

                }
            }

        }
        public Product[] FindAllMeat()
        {
            return products.Where(x => x is Meat).ToArray();

        }
        public void ChangeAllPrice(double percentage)
        {
            foreach (var item in products)
            {
                item.ChangePrice(percentage);
            }
        }
        public void FindSpoiledDairyProducts(string pathToSave)
        {
            StreamWriter writer = new StreamWriter(pathToSave);
            Product[] dairy = products.Where(x => x is DairyProducts).ToArray();
            Product[] spoiled = dairy.Where(x => x.ExpirationInDays < (int)((DateTime.Today - x.Date).TotalDays)).ToArray();
            StringBuilder text = new StringBuilder();
            foreach (Product item in spoiled)
            {
                text.Append(item);
            }
            writer.Write(text);
            writer.Close();
        }




    }
}
