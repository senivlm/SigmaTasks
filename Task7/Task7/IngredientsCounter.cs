using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Task7
{
    public class IngredientsCounter
    {
        //Fields
        private Dictionary<string, double[]> ingredients;
        private Dictionary<string, double> ingredientPrice;
        



        //Constructors
        public IngredientsCounter(string menuPath="",string pricePath="")
        {
            try
            {
                ingredients = new Dictionary<string, double[]>();
                ingredientPrice = new Dictionary<string, double>();
                if (menuPath!="")
                {
                    ReadMenuFile(menuPath);
                }
                if (pricePath != "")
                {
                    ReadIngredientsPriceFile(pricePath);
                    CountIngredientPrice();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        //Methods
        public void ReadMenuFile(string path)
        {
            try
            {
                string[] menu=File.ReadAllLines(path);
                for (int i = 0; i < menu.Length; i++)
                {
                    string[] ingredient = menu[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (ingredient.Length == 2)
                    {
                        double weigth = double.Parse(ingredient[1]);
                        if (!ingredients.ContainsKey(ingredient[0]))
                            ingredients.Add(ingredient[0], new double[2] { weigth, 0 });
                        else
                            ingredients[ingredient[0]][0] += weigth;
                    }
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void ReadIngredientsPriceFile(string path)
        {
            try
            {
                string[] ingredientPrice = File.ReadAllLines(path);
                for (int i = 0; i < ingredientPrice.Length; i++)
                {
                    string[] ingredient = ingredientPrice[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (ingredient.Length == 2)
                    {
                        double price = double.Parse(ingredient[1]);
                        if (!this.ingredientPrice.ContainsKey(ingredient[0]))
                            this.ingredientPrice.Add(ingredient[0], price);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CountIngredientPrice()
        {
            foreach (KeyValuePair<string,double[]> ingredient in ingredients)
            {
                try
                {
                    ingredient.Value[1] = ingredient.Value[0] * ingredientPrice[ingredient.Key];
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            foreach (var item in ingredients)
            {
                text.Append(string.Format($"{item.Key,-12}{item.Value[0],-7:0.###}{item.Value[1],-7:0.###}\n"));
            }
            return text.ToString();
        }

    }
}
