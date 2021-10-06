using NET01._2.Matriсes;
using System;

namespace NET01._2
{
    class Program
    {
        delegate void ChangeValue (int indexI, int indexJ, int value);
        /// <summary>
        /// Test Maxtrix classes
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SquareMatrix<int> integerMatrix = new SquareMatrix<int>(5);
            integerMatrix[1, 1] = 8;
            Console.WriteLine(integerMatrix.ToString());
            Console.WriteLine("Element with index [1,1] = " + integerMatrix[1, 1] + "\n");
            //Try to check matrix with negative size
            try
            {
                Console.WriteLine("Check matrix with negative size : ");
                SquareMatrix<int> integerMatrix2 = new SquareMatrix<int>(-5);
            }
            catch (Exception exaption)
            {
                Console.WriteLine(exaption.Message);
            }
            Console.WriteLine();
            //Try to check matrix with change incorrect index
            try
            {
                Console.WriteLine("Checking for matrix change by wrong index : ");
                SquareMatrix<int> integerMatrix2 = new SquareMatrix<int>(5);
                integerMatrix2[5, 1] = 30;
                Console.WriteLine(integerMatrix2.ToString());
            }
            catch (Exception exaption)
            {
                Console.WriteLine(exaption.Message);
            }
            Console.WriteLine();
            //Create diagonal matrix
            DiagonalMatrix<int> diagonalIntegerMatrix = new DiagonalMatrix<int>(5);
            Console.WriteLine(diagonalIntegerMatrix.ToString());
            diagonalIntegerMatrix[1, 1] = 1;
            Console.WriteLine(diagonalIntegerMatrix.ToString());
            //Try to change value not diagonal element
            try
            {
                Console.WriteLine("Check to change not diagonal element of matrix :");
                diagonalIntegerMatrix[1, 2] = 1;
            }
            catch (Exception exaption)
            {
                Console.WriteLine(exaption.Message);
            }
            //Try to change value not in correct index
            try
            {
                Console.WriteLine("Check to change incorrect index of matrix :");
                diagonalIntegerMatrix[5, 5] = 1;
            }
            catch (Exception exaption)
            {
                Console.WriteLine(exaption.Message);
            }
            Console.WriteLine();
            //Check diagonal matrix with string type
            DiagonalMatrix<string> diagonalMatrix = new DiagonalMatrix<string>(5);
            diagonalMatrix[0, 0] = "1";
            diagonalMatrix[1, 1] = "1";
            diagonalMatrix[2, 2] = "1";
            diagonalMatrix[3, 3] = "1";
            diagonalMatrix[4, 4] = "1";
            Console.WriteLine(diagonalMatrix.ToString());
            //Change value by method
            integerMatrix.ChangeValueOfSquareMatrix(0, 0, 10);
            Console.WriteLine(integerMatrix.ToString());
            //Change value by anonymous method
            ChangeValue operation = delegate (int indexI, int indexJ, int value)
            {
                integerMatrix[indexI, indexJ] = value;
            };
            operation(3, 3, 10);
            Console.WriteLine(integerMatrix.ToString()); Console.WriteLine();
            //Change value by lyambda operation 
            operation = (indexI, indexJ, value) => integerMatrix[indexI, indexJ] = value;
            operation(4, 1, 30);
            Console.WriteLine(integerMatrix.ToString()); Console.WriteLine();
        }
    }
}
