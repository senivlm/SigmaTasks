using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace Task9
{
    public class Storage : IEnumerator<Product>, IEnumerable<Product>
    {
        public event LogToFileDelegate LogEvent;
        public event ReplaceProductDelegate ReplaceEvent;
        
        

        private List<Product> products;
        private int currentIndex = -1;
        private Product currentProduct;

        public int Size { get=>products.Count; 
        }

        public Product Current
        {
            get => currentProduct;
        }

        object IEnumerator.Current
        {
            get => Current;
        }




        public Storage(int size = 0)
        {
            if (size >= 0)
            {
                products = new List<Product>(size);
            }
            
        }
        public Storage(List<Product> products)
        {
            this.products = new List<Product>();
            this.products.AddRange(products);
            
        }



        public Product this[int index]
        {
            get
            {
                if (products != null && index < products.Count && index>=0)
                {
                    return products[index];
                }

                return null;
            }
            set
            {
                if (products != null && index < products.Count && index >= 0)
                {
                    products[index] = value;
                }

            }
        }

        
        

        public void AddProductFromFile(string readPath,string logPath)
        {
            using (StreamReader file = new StreamReader(readPath))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    List<string> words=line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    Product temp;
                    try
                    {

                        switch (words[0])
                        {
                            case "p":
                                temp = new Product();
                                temp.Parse(string.Join(" ", words.Skip(1)));
                                products.Add(temp);
                                break;
                            case "m":
                                temp = new Meat();
                                temp.Parse(string.Join(" ", words.Skip(1)));

                                products.Add(temp);
                                break;
                            case "d":
                                temp = new DairyProducts();
                                temp.Parse(string.Join(" ", words.Skip(1)));
                                products.Add(temp);
                                break;
                            default:
                                LogEvent?.Invoke(logPath, (new FormatException("Product type format exception").ToString()), string.Join(" ", words));
                                ReplaceEvent?.Invoke(this, string.Join(" ", words));
                                break;
                        }
                    }
                    catch (FormatException ex)
                    {
                        LogEvent?.Invoke(logPath, ex.ToString(), string.Join(" ", words));
                        ReplaceEvent?.Invoke(this, string.Join(" ", words));
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    
                }
                
            }
               
        }

        public void InitStorageFromFile(string readPath,string logPath)
        {
            products.Clear();
            try
            {
                AddProductFromFile(readPath, logPath);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new NullReferenceException("AddProduct null reference exception");
            products.Add(product);
        }

        public void DeleteProduct(string name)
        {
            products = products.Where(prod => prod.Name != name).ToList();
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

        public List<Product> FindByAttribute(object attribute,CompareToEqualityDelegate compare)
        {
            if (compare == null)
                throw new NullReferenceException();
            return products.Where(prod => compare.Invoke(attribute, prod)).ToList();
        }
        public List<Product> FindAllMeat()
        {
            return products.Where(x => x is Meat).ToList();

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
        public void DeleteAllProduct()
        {
            products.Clear();
        }
        public bool MoveNext()
        {
            if (++currentIndex >= products.Count)
                return false;
            else
                currentProduct = products[currentIndex];

            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {

        }

        public IEnumerator<Product> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
