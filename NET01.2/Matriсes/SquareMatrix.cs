using System;
using System.Text;


namespace NET01._2.Matriсes
{
    /// <summary>
    /// Class describing a square matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SquareMatrix<T>
    {
        T [] _array;
        int _size;
        delegate void ChangeValueHandler(int i, int j, T value);
        event ChangeValueHandler _Notify;
        public SquareMatrix(int size)
        {
            Size = size;
            _array = new T[Size * Size];
        }
        /// <summary>
        /// Property Size
        /// </summary>
        /// <returns>Size of square matrix</returns>
        public virtual int Size
        {
            get { return _size; }
            set
            {
                if (value >= 0)
                {
                    _size = value;
                }
                else
                {
                    throw new Exception("Size of matrix can't be negative.");
                }
            }
        }
        /// <summary>
        /// Matrix array access indexer 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public virtual T this[int i, int j]
        {
            get
            {
                if (CheckIndex(i, j))
                {
                    return _array[i * _size + j];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if(CheckIndex(i,j))
                {
                    _Notify += ChangeValue;
                    _Notify(i, j, _array[i * _size + j]);
                    _Notify -= ChangeValue;
                    _array[i * _size + j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        /// <summary>
        /// Method for Check valid index in square matrix
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool CheckIndex(int i, int j)
        {
            return i >= 0 && i < Size && j >= 0 && j < Size;
        }
        /// <summary>
        /// Ovveriden method ToString()
        /// </summary>
        /// <returns>String representation of a matrix</returns>
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    outputString.Append(_array[i * _size + j] + " ");
                }
                outputString.Append("\n");
            }
            return outputString.ToString();
        }
        private void ChangeValue(int i, int j, T value)
        {
            Console.WriteLine($"Element with index [{i},{j}] was changed, old value = {value}");
        }
        /// <summary>
        /// Method for change value from code without indexer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void ChangeValueOfSquareMatrix(int i, int j, T value)
        {
            if (CheckIndex(i,j))
            {
                _Notify += ChangeValue;
                _Notify(i, j, _array[i * _size + j]);
                _Notify -= ChangeValue;
                _array[i * _size + j] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
