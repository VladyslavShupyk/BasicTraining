using System;

namespace NET02._1
{
    /// <summary>
    /// Class describing Author of book
    /// </summary>
    public class Author
    {
        const int _MAX_LENGTH = 200;
        string _firstName;
        string _lastName;
        /// <summary>
        /// Property of author first name
        /// </summary>
        public string FirstName 
        {
            get
            {
                return _firstName;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    if (value.Length <= _MAX_LENGTH)
                    {
                        _firstName = value;
                    }
                    else
                    {
                        throw new Exception($"First name can be up to {_MAX_LENGTH} characters.");
                    }
                }
                else
                {
                    throw new Exception("First name can't be empty or null.");
                }
            }
        }
        /// <summary>
        /// Property of author last name
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (value.Length <= _MAX_LENGTH)
                    {
                        _lastName = value;
                    }
                    else
                    {
                        throw new Exception($"Last name can be up to {_MAX_LENGTH} characters.");
                    }
                }
                else
                {
                    throw new Exception("Last name can't be empty or null.");
                }
            }
        }
        public Author(string name, string lastname)
        {
            FirstName = name;
            LastName = lastname;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
