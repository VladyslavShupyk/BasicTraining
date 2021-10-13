using System;
using System.Text;


namespace NET01._2.Matriсes
{
    /// <summary>
    /// Class describing a square matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T>
    {
        protected T [] _array;
        int _size;
        public delegate void ChangeValueHandler(int i, int j, T value);
        public event ChangeValueHandler NotifyChange;
        public SquareMatrix(int size)
        {
            Size = size;
            _array = new T[Size * Size];
        }
        protected SquareMatrix() { }
        /// <summary>
        /// Property Size
        /// </summary>
        /// <returns>Size of square matrix</returns>
        public int Size
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
                    return _array[i * Size + j];
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
                    if (!_array[i * Size + j].Equals(value))
                    {
                        OnNotifyChange(i, j, _array[i * Size + j]);
                        _array[i * Size + j] = value;
                    }
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
        protected virtual bool CheckIndex(int i, int j)
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
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    outputString.Append(_array[i * Size + j] + " ");
                }
                outputString.Append("\n");
            }
            return outputString.ToString();
        }
        protected void OnNotifyChange(int i, int j, T value)
        {
            NotifyChange?.Invoke(i, j, value);
        }
        /// <summary>
        /// Method for change value from code without indexer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public virtual void ChangeValueOfMatrix(int i, int j, T value)
        {
            if (CheckIndex(i,j))
            {
                OnNotifyChange(i, j, _array[i * Size + j]);
                _array[i * _size + j] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
