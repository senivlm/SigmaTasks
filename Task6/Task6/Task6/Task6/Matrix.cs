using System;
using System.Collections;
using System.Text;
namespace Task6
{
    public class Matrix: IEnumerator,IEnumerable        
    {
        private int[,] matrix;
        private int rows;
        private int columns;
        private int rowPosition, columnPosition;

        public object Current => matrix[rowPosition, columnPosition];

        public (int rows,int columns) Size
        {
            get=> (rows,columns);
            set
            {
                if (value.Item1 < 0 || value.Item2 < 0)
                    throw new IndexOutOfRangeException();
                rows = value.Item1;
                columns = value.Item2;
                matrix = new int[rows, columns];
                Reset();
            }
        }

        public Matrix(int rows=0,int columns=0)
        {
            try
            {
                Size = (rows, columns);
                Reset();
                InitMatrix();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public void InitMatrix()
        {
            Random r = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = r.Next(0, 100);
                }
            }
        } 
        public bool MoveNext()
        {
            --columnPosition;
            if (columnPosition < 0)
            {
                --rowPosition;
                columnPosition = columns - 1;
            }
            return rowPosition >= 0 && columnPosition >= 0;
        }

        public void Reset()
        {
            rowPosition = rows-1;
            columnPosition = columns;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result.Append(string.Format($"{matrix[i,j],-5} "));
                }
                result.AppendLine();
                
            }
            return result.ToString();
        }

        public int this[int rIndex, int cIndex]
        {
            get
            {
                if (rIndex < 0 || rIndex >= rows || cIndex < 0 || cIndex >= columns)
                    throw new IndexOutOfRangeException();
                return matrix[rIndex, cIndex];
            }
            set
            {
                if (rIndex < 0 || rIndex >= rows || cIndex < 0 || cIndex >= columns)
                    throw new IndexOutOfRangeException();
                matrix[rIndex, cIndex] = value;
            }
        }
    }
}
