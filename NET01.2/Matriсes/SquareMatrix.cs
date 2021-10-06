using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._2.Matriсes
{
    /// <summary>
    /// Class describing a square matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SquareMatrix<T>
    {
        T [] array;
        int size;
        delegate void ChangeValueHandler(int indexI, int IndexJ, T value);
        event ChangeValueHandler Notify;
        /// <summary>
        /// Constructor of matrix
        /// </summary>
        /// <param name="size"></param>
        public SquareMatrix(int size)
        {
            if (size >= 0)
            {
                array = new T[size * size];
                this.size = size;
            }
            else
                throw new Exception("Size of matrix can't be negative.");
        }
        /// <summary>
        /// Matrix size access property 
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (size >= 0)
                {
                    array = new T[value * value];
                    size = value;
                }
                else
                    throw new Exception("Size of matrix can't be negative.");
            }
        }
        /// <summary>
        /// Matrix array access indexer
        /// </summary>
        /// <param name="indexI"></param>
        /// <param name="indexJ"></param>
        /// <returns>Element by index</returns>
        /// <sets>Value by index</sets>
        public T this[int indexI, int indexJ]
        {
            get
            {
                if (indexI >= 0 && indexI < size && indexJ >= 0 && indexJ < size)
                {
                    int indexOfElement = 0;
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (i == indexI && j == indexJ)
                            {
                                break;
                            }
                            indexOfElement++;
                        }
                    }
                    return array[indexOfElement];
                }
                else
                    throw new Exception("Invalid element index");
            }
            set
            {
                if (indexI >= 0 && indexI < size && indexJ >= 0 && indexJ < size)
                {
                    int indexOfElement = 0;
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (i == indexI && j == indexJ)
                            {
                                T item1 = array[indexOfElement];
                                T item2 = value;
                                if(!EqualityComparer<T>.Default.Equals(item1, item2))
                                {
                                    Notify += ChangeValue;
                                    Notify(i, j, array[indexOfElement]);
                                    Notify -= ChangeValue;
                                    array[indexOfElement] = value;
                                    break;
                                }
                            }
                            indexOfElement++;
                        }
                    }
                }
                else
                    throw new Exception("Invalid element index");
            }
        }
        /// <summary>
        /// Ovveriden method ToString()
        /// </summary>
        /// <returns>String representation of a matrix</returns>
        public override string ToString()
        {
            int sizeOfMatrix = Size;
            string outputMatrix = String.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                outputMatrix += array[i] + " ";
                if (i == sizeOfMatrix - 1)
                {
                    outputMatrix += "\n";
                    sizeOfMatrix += Size;
                }
            }
            return outputMatrix;
        }
        private void ChangeValue(int indexI, int indexJ, T value)
        {
            Console.WriteLine($"Element with index [{indexI},{indexJ}] was changed, old value = {value}");
        }
        /// <summary>
        /// Method for change value from code without indexer
        /// </summary>
        /// <param name="indexI"></param>
        /// <param name="indexJ"></param>
        /// <param name="value"></param>
        public void ChangeValueOfSquareMatrix(int indexI, int indexJ, T value)
        {
            if (indexI >= 0 && indexI < size && indexJ >= 0 && indexJ < size)
            {
                int indexOfElement = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i == indexI && j == indexJ)
                        {
                            T item1 = array[indexOfElement];
                            T item2 = value;
                            if (!EqualityComparer<T>.Default.Equals(item1, item2))
                            {
                                Notify += ChangeValue;
                                Notify(i, j, array[indexOfElement]);
                                Notify -= ChangeValue;
                                array[indexOfElement] = value;
                                break;
                            }
                        }
                        indexOfElement++;
                    }
                }
            }
            else
                throw new Exception("Invalid element index");
        }
    }
}
