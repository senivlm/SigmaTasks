using System;
using System.Text;
namespace Practice
{
    public class Projection
    {
        private int[,,] matrix3D;
        private int[][,] matrix2D;//Projections xy/xz/yz
        private int xSize, ySize, zSize;

        public Projection(int xSize,int ySize,int zSize)
        {
            this.xSize = xSize;
            this.ySize = ySize;
            this.zSize = zSize;
            matrix3D = new int[zSize, ySize, xSize];// { { { 1, 1, 1}, { 1, 1, 1 }, { 1, 1, 1 } }, { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }, { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } } };
            
            Init3dMatrix();
            matrix2D = new int[3][,];
            matrix2D[0] = new int[ySize, xSize];
            matrix2D[1] = new int[zSize, xSize];
            matrix2D[2] = new int[zSize, ySize];
        }

        public void Init3dMatrix()
        {
            Random r = new Random();

            for (int i = 0; i < zSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    for (int k = 0; k < xSize; k++)
                    {
                        matrix3D[i, j, k] = r.Next(0, 2);
                    }
                }
            }


        }

        public void Create2dImage()
        {
            for (int i = 0; i < zSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    for (int k = 0; k < xSize; k++)
                    {
                        if (matrix3D[i, j, k] == 1)
                        {
                            matrix2D[0][j, k] = 1;
                            matrix2D[1][i, k] = 1;
                            matrix2D[2][j, i] = 1;

                        }

                    }
                }
            }

        }
        public override string ToString()
        {

            StringBuilder temp = new StringBuilder("xy\n");
            
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {
      
                    temp.Append(matrix2D[0][i, j]);
                }
                temp.Append( "\n");
            }
            temp.Append("\nxz\n");
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {

                    temp.Append(matrix2D[1][i, j]);
                }
                temp.Append("\n");
            }
            temp.Append("\nzy\n");
            for (int i = 0; i < ySize; i++)
            {
                for (int j = 0; j < xSize; j++)
                {

                    temp.Append(matrix2D[2][i, j]);
                }
                temp.Append("\n");
            }

            return temp.ToString(); 
        }
    }
    
}
