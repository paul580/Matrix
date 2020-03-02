using System;

namespace Matrix
{
    class Matrix
    {
        private int[,] grid;

        private int girdSize;

        public Matrix(int[,] girdValues, int girdSize)
        {
            this.grid = girdValues;
            this.girdSize = girdSize;
        }

        public void PrintMatrix()
        {
            //iterar filas
            for (int y = 0; y < this.girdSize; y++)
            {
                //iterar columnas
                for (int x = 0; x < this.girdSize; x++)
                {
                    //imprimir 
                    Console.Write(this.grid[y, x]);
                }
                Console.WriteLine();
            }
        }
        public int CalculateDeterminantMexicanStyle()
        {
            return this.grid[0, 0] * this.grid[1, 1] * this.grid[2, 2]
            + this.grid[0, 1] * this.grid[1, 2] * this.grid[2, 0]
            + this.grid[0, 2] * this.grid[1, 0] * this.grid[2, 1]
            - this.grid[0, 2] * this.grid[1, 1] * this.grid[2, 0]
            - this.grid[0, 0] * this.grid[1, 2] * this.grid[2, 1]
            - this.grid[0, 1] * this.grid[1, 0] * this.grid[2, 2];
        }
        public int CalculateDeterminant()
        {
            int resultado = 0;

            // iterar diagonales
            for (int i = 0; i < this.girdSize; i++)
            {

                int diagonalResult = 1;

                //clacular el valor de y que siempre es 0, 1 ,2
                for (int y = 0; y < this.girdSize; y++)
                {

                    // calcular x
                    // la x es 0, luego 1, luego 2, pero dependiendo
                    // del # de la iteracion, se le suma un numero
                    int x = y + i;

                    if (x >= this.girdSize)
                    {
                        x = x - this.girdSize;
                    }
                    diagonalResult = diagonalResult * this.grid[y, x];
                }

                resultado += diagonalResult;
            }
            //resultado = resultado + diagonalResult;

            //iterar segundas {3} diganales
            for (int i = 0; i < this.girdSize; i++)
            {

                int diagonalResult = 1;

                //calcular valor de y que siempre es 0, 1, 2
                for (int y = 0; y < this.girdSize; y++)
                {
                    int x = (this.girdSize - 1) - y;

                    x -= i * (this.girdSize - 1);

                    while (x < 0)
                    {
                        x += this.girdSize;
                    }
                    diagonalResult *= this.grid[y, x];
                }
                resultado -= diagonalResult;
            }
            return resultado;
        }
    }
}