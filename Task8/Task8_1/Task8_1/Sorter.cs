using System;
namespace Task8_1
{
    public static class Sorter
    {
        
        public static void BubbleSort( object[] array,ComparatorDelegate comparator)
        {
            
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    try
                    {
                        if (comparator?.Invoke(array[j], array[j + 1]) == 1)
                        {
                            object temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    
                }
            } 
        }
    }
}
