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
        public DiagonalMatrix(int size)
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
                    if (!_array[i].Equals(value))
                    {
                        OnNotifyChange(i, j, _array[i]);
                        _array[i] = value;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        /// <summary>
        /// Ovveriden method ToString()
        /// </summary>
        /// <returns>String representation of a matrix</returns>
        public override string ToString()
        {
            StringBuilder outputstring = new StringBuilder();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
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
        public override void ChangeValueOfMatrix(int i, int j, T value)
        {
            if(CheckIndex(i,j))
            {
                if (!_array[i].Equals(value))
                {
                    OnNotifyChange(i, j, _array[i]);
                    _array[i] = value;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        protected override bool CheckIndex(int i, int j)
        {
            return i == j;
        }
    }
}
