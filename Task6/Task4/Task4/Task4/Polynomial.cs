using System;
using System.Collections.Generic;
using System.Text;
namespace Task4
{
    public class Polynomial
    {
        private SortedDictionary<int, double> coeffs;
        private const double approximateZero = 1e-6;

        public Polynomial(params (int, double)[] coeffs)
        {


            this.coeffs = new SortedDictionary<int, double>();

            for (int i = 0; i < coeffs.Length; i++)
            {

                if (coeffs[i].Item2 > approximateZero || coeffs[i].Item2 < -approximateZero)
                    this.coeffs.Add(coeffs[i].Item1, coeffs[i].Item2);
            }

        }
        public Polynomial()
        {
            coeffs = new SortedDictionary<int, double>();
        }
        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            foreach (KeyValuePair<int, double> item in coeffs)
            {

                if (item.Key != 0)
                {
                    if (item.Value >= 0)
                        temp.Append(string.Format($"{item.Value:0.###}x^{item.Key} + "));
                    else
                        temp.Append(string.Format($"({item.Value:0.###})x^{item.Key} + "));
                }
                else
                    temp.Append(string.Format($"{item.Value:0.###} + "));
            }


            temp.Remove(temp.Length - 3, 2);
            return temp.ToString();
        }
        public double this[int power]
        {
            set
            {
                if (power < 0)
                    throw new IndexOutOfRangeException();
                if (coeffs.ContainsKey(power))
                {
                    if (!(value > approximateZero || value < -approximateZero))
                        coeffs.Remove(power);
                    else
                        coeffs[power] = value;
                }
                else
                    if (value > approximateZero || value < -approximateZero)
                        coeffs.Add(power, value);

            }
        }

        public void Parse(string s)
        {
            s = s.Replace("(", "");
            s = s.Replace(")", "");
            string[] splitedS = s.Split("+");

            string[][] coeffsAndPowers = new string[splitedS.Length][];
            for (int i = 0; i < coeffsAndPowers.Length; i++)
            {
                coeffsAndPowers[i] = splitedS[i].Split("x^", StringSplitOptions.RemoveEmptyEntries);
            }
            coeffs.Clear();
            int power = 0, start = 0;
            double coeff = 0;
            if (coeffsAndPowers[0].Length == 1)
            {
                try
                {
                    coeff = double.Parse(coeffsAndPowers[0][0]);
                }
                catch (Exception ex)
                {
                    throw;
                }
                coeffs.Add(0, coeff);
                start = 1;
            }
            for (int i = start; i < coeffsAndPowers.Length; i++)
            {
                try
                {
                    power = int.Parse(coeffsAndPowers[i][1]);
                    coeff = double.Parse(coeffsAndPowers[i][0]);
                }
                catch (Exception ex)
                {
                    throw;
                }
                coeffs.Add(power, coeff);
            }
        }

        public Polynomial Add(Polynomial p)
        {
            Polynomial newP = new Polynomial();
            foreach (KeyValuePair<int, double> item in p.coeffs)
            {
                if (coeffs.ContainsKey(item.Key))
                {
                    double sum = item.Value + coeffs[item.Key];
                    if (sum>approximateZero || sum<-approximateZero)
                        newP.coeffs.Add(item.Key, sum);
                }   
                else
                    newP.coeffs.Add(item.Key, item.Value);
            }
            foreach (KeyValuePair<int, double> item in coeffs)
            {
                if (!newP.coeffs.ContainsKey(item.Key))
                    newP.coeffs.Add(item.Key, item.Value);
            }
            return newP;
        }

        public Polynomial Subtract(Polynomial p)
        {
            Polynomial newP = new Polynomial();
            foreach (KeyValuePair<int, double> item in p.coeffs)
            {
                if (coeffs.ContainsKey(item.Key))
                {
                    double diff = coeffs[item.Key]-item.Value;
                    if (diff > approximateZero || diff < -approximateZero)
                        newP.coeffs.Add(item.Key, diff);
                } 
                else
                    newP.coeffs.Add(item.Key, -item.Value);
            }
            foreach (KeyValuePair<int, double> item in coeffs)
            {
                if (!newP.coeffs.ContainsKey(item.Key))
                    newP.coeffs.Add(item.Key, item.Value);
            }

            return newP;

        }

        public Polynomial Myltiply(Polynomial p)
        {
            Polynomial newP = new Polynomial();
            int temp = 0;
            foreach (var item1 in coeffs)
            {
                foreach (var item2 in p.coeffs)
                {
                    
                    temp = item1.Key + item2.Key;
                    if (newP.coeffs.ContainsKey(temp))
                        newP.coeffs[temp] += item1.Value * item2.Value;
                    else
                        newP.coeffs.Add(temp, item1.Value * item2.Value);
                    
                }
            }
            return newP;
        }

        public static Polynomial operator+ (Polynomial p1, Polynomial p2)
        {
            return p1.Add(p2);
        }
        public static Polynomial operator- (Polynomial p1, Polynomial p2)
        {
            return p1.Subtract(p2);
        }
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            return p1.Myltiply(p2);
        }
        public static implicit operator Polynomial(double value)
        {
            return new Polynomial((0,value));
        }
        
    }
}
