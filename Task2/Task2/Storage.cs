using System;
using System.Linq;
namespace Task2
{
    public class Storage
    {
        private Product[] products;
        public Product this[int index]
        {
            get
            {
                if (products!=null && index<products.Length)
                {
                    return products[index];
                }
                
                return null;
            }
            set
            {
                if (products != null && index<products.Length)
                {
                    products[index] = value;
                }
                
            }
        }
        public Storage(int size=0)
        {
            if (size>=0)
            {
                products = new Product[size];
            }
        }
        
        
        public void AutoInit()
        {
            products = new Product[3];
            string[] name = { "Cola", "Pork","Cheese"};
            double[] price = { 12, 56, 43 };
            double[] weight = { 1, 2, 0.5 };
            if (products!=null)
            {
                products[0] = new Product(name[0],price[0],weight[0]);
                products[1] = new Meat(name[1], price[1], weight[1], Meat.Category.I, Meat.Type.Pork);
                products[2] = new DairyProducts(name[2],price[2],weight[2],30);
            }


        }
        public override string ToString()
        {
            string temp = "";
            if (products!=null)
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
            var item=ProductRead();
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
            return (item.Item1,item.Item2,item.Item3, ctgr, tp);
        }
        private (string, double, double, int) DairyProductsRead()
        {
            var item = ProductRead();
            
            Console.WriteLine("Enter expiration date (date>0)");
            string sdate=Console.ReadLine();
            int date;
            int.TryParse(sdate, out date);
            return (item.Item1,item.Item2,item.Item3, date);
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
                        var item= ProductRead();
                        products[i] = new Product(item.Item1,item.Item2,item.Item3);
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
        



    }
}
