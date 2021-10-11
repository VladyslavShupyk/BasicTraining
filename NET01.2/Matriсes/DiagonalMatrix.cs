using System;
using System.Text;

namespace NET01._2.Matriсes
{
    /// <summary>
    /// Class describing a diagonal matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class DiagonalMatrix<T> : SquareMatrix<T>
    {
        T [] _array;
        int _size;
        delegate void ChangeValueHandler(int i, int j, T value);
        event ChangeValueHandler _Notify;
        /// <summary>
        /// Property Size
        /// </summary>
        /// <returns>Size of diagonal matrix</returns>
        public override int Size
        {
            get { return _size; }
            set
            {
                if (value >= 0)
                {
                    _size = value;
                }
                else
                    throw new Exception("Size of matrix can't be negative.");
            }
        }
        public DiagonalMatrix(int size) : base(size)
        {
            Size = size;
            _array = new T[Size];
        }
        /// <summary>
        /// Matrix array access indexer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>Element by index</returns>
        /// <sets>Value by index</sets>
        public override T this[int i, int j]
        {
            get
            {
                if(CheckIndex(i,j))
                {
                    return _array[i];
                }
                else
                {
                    return default;
                }    
            }
            set
            {
                if(CheckIndex(i,j))
                {
                    _Notify += ChangeValue;
                    _Notify(i, j, _array[i]);
                    _Notify -= ChangeValue;
                    _array[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        private void ChangeValue(int i, int j, T value)
        {
            Console.WriteLine($"Element with index [{i},{j}] was changed, old value = {value}");
        }
        /// <summary>
        /// Ovveriden method ToString()
        /// </summary>
        /// <returns>String representation of a matrix</returns>
        public override string ToString()
        {
            StringBuilder outputstring = new StringBuilder();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (i != j)
                    {
                        outputstring.Append((T)default + " ");
                    }
                    else
                    {
                        outputstring.Append(_array[i] + " ");
                    }
                }
                outputstring.Append("\n");
            }
            return outputstring.ToString();
        }
        /// <summary>
        /// Method for change value from code without indexer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void ChangeValueOfDiagonalMatrix(int i, int j, T value)
        {
            if(CheckIndex(i,j))
            {
                _Notify += ChangeValue;
                _Notify(i, j, _array[i]);
                _Notify -= ChangeValue;
                _array[i] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        private bool CheckIndex(int i, int j)
        {
            return i == j;
        }
    }
}
