using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NET02._1
{
    public class Book
    {
        const int _MAX_LENGTH_NAME = 1000;
        string _name;
        string _isbn;
        public DateTime Date { get; set; }
        public List<Author> authors;
        public string ISBN 
        {
            get
            {
                return _isbn;
            }
            set
            {
                if(CheckISBN(value))
                {
                    _isbn = value.Replace("-", "");
                }
                else
                {
                    throw new Exception("Not valid ISBN.");
                }
            } 
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (value.Length <= _MAX_LENGTH_NAME)
                    {
                        _name = value;
                    }
                    else
                    {
                        throw new Exception($"Name of book can be up to {_MAX_LENGTH_NAME} characters.");
                    }
                }
                else
                {
                    throw new Exception("Name of book can't be empty or null.");
                }
            }
        }
        public Book(string name,string isbn)
        {
            Name = name;
            ISBN = isbn;
        }
        public Book(string name, string isbn, Author author)
        {
            Name = name;
            ISBN = isbn;
            authors = new List<Author>();
            authors.Add(author);
        }
        public Book(string name, string isbn, Author author, DateTime date)
        {
            Name = name;
            ISBN = isbn;
            authors = new List<Author>();
            authors.Add(author);
            Date = date;
        }
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            outputString.Append("Book name - " + Name + "\n");
            outputString.Append("Authors book : " + "\n");
            foreach (var author in authors)
            {
                outputString.Append(author.FirstName + " " + author.LastName + "\n");
            }
            outputString.Append("ISBN - " + ISBN + "\n");
            outputString.Append("Date create of book - " + Date + "\n");
            return outputString.ToString();
        }
        public bool Equals(Book book)
        {
            return this._isbn == book._isbn;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj is Book)
            {
                return Equals(obj as Book);
            }
            else
            {
                return false;
            }
        }
        private bool CheckISBN(string isbn)
        {
            return Regex.IsMatch(isbn, "^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$") || Regex.IsMatch(isbn, "^[0-9]{13}$");
        }
    }
}
