using System;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IngredientsCounter counter = new IngredientsCounter(@"/Users/artemhuk/Desktop/Menu.txt",
                    @"/Users/artemhuk/Desktop/Price.txt");
                Console.WriteLine(string.Format("{0,-12}{1,-7}{2,-7}","Ingredient","Weight","Price"));
                Console.WriteLine(counter);

                Vocabulary vocabulary = new Vocabulary(new WordReader(),@"/Users/artemhuk/Desktop/Dictionary.txt");
                Console.WriteLine(vocabulary.ChangeWords("I go to school. Girl runs to school."));
                Console.WriteLine(vocabulary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
