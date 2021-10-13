using NET01._2.Matriсes;
using System;

namespace NET01._2
{
    class Program
    {
        /// <summary>
        /// Test Maxtrix classes
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(5);
            Console.WriteLine("Squre matrix : \n" + squareMatrix.ToString());
            squareMatrix.NotifyChange += ShowChanges;
            squareMatrix[2, 2] = 5;
            Console.WriteLine("Squre matrix : \n" + squareMatrix.ToString());
            squareMatrix[2, 2] = 10;
            Console.WriteLine("Squre matrix : \n" + squareMatrix.ToString());
            Console.WriteLine("Try to change elemet with incorrect index : ");
            try
            {
                squareMatrix[5, 5] = 20;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message); 
            }
            Console.WriteLine();
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(5);
            Console.WriteLine("Diagonal matrix : \n" + diagonalMatrix.ToString());
            diagonalMatrix.NotifyChange += ShowChanges;
            diagonalMatrix[1, 1] = 1;
            Console.WriteLine("Diagonal matrix : \n" + diagonalMatrix.ToString());
            diagonalMatrix[0, 0] = 1;
            Console.WriteLine("Diagonal matrix : \n" + diagonalMatrix.ToString());
            diagonalMatrix[0, 0] = 1; //Check event not call if values are equal
            diagonalMatrix.NotifyChange += (i, j, value) => { Console.WriteLine("Value of matrix[" + i + "," + j + "] changed, Old value matrix[" + i + "," + j + "] = " + value); };
            diagonalMatrix.NotifyChange += delegate (int i, int j, int value)
            {
                Console.WriteLine("Value of matrix[" + i + "," + j + "] changed, Old value matrix[" + i + "," + j + "] = " + value);
            };
            diagonalMatrix[2, 2] = 1;
        }
        private static void ShowChanges(int i, int j, int value)
        {
            Console.WriteLine("Value of matrix[" + i + "," + j + "] changed, Old value matrix[" + i + "," + j +"] = " + value);
        }
    }
}
