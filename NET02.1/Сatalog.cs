using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET02._1
{
    public class Catalog : IEnumerable
    {
        int _count;
        public List<Book> books;
        public int Count
        {
            get { return _count; }
        }
        #region Constructors
        public Catalog()
        {
            books = new List<Book>();
        }
        public Catalog(params Book [] books)
        {
            this.books = new List<Book>();
            foreach(Book book in books)
            {
                this.books.Add(book);
                _count++;
            }
        }
        #endregion
        public void Add(Book book)
        {
            books.Add(book);
            _count++;
        }
        public void RemoveByIsbn(string isbn)
        {
            foreach (var book in books)
                if (book.ISBN == isbn)
                {
                    books.Remove(book);
                    _count--;
                }         
        }
        public void RemoveByBookName(string name)
        {
            foreach(var book in books)
            {
                if (book.Name == name)
                {
                    books.Remove(book);
                    _count--;
                }
            }                    
        }
        public void Remove(Book book)
        {
            if (books.Remove(book))
            {
                _count--;
            }
        }

        public IEnumerator GetEnumerator()
        {
            books.Sort((book1, book2) => book1.Name.CompareTo(book2.Name));
            foreach(var book in books)
            {
                yield return book;
            }
        }
        public Book this[string isbn]
        {
            get
            {
                string isbnNormalize = isbn.Replace("-", "");
                foreach (var book in books)
                {
                    if (book.ISBN == isbnNormalize)
                    {
                        return book;
                    }
                }
                return null;
            }
            set { }
        }
        public List<Book> GetBooksByAuthorNameAndSurname(string firstName, string lastName)
        {
            var books = from book in this.books
                        from author in book.authors
                        where author.FirstName == firstName && author.LastName == lastName
                        select book;
            List<Book> newBooks = new List<Book>();
            foreach(var book in books)
            {
                newBooks.Add(book);
            }
            return newBooks;
        }
        public List<Book> GetBooksByDateSortedDescending()
        {
            var books = from book in this.books
                        orderby book.Date descending
                        select book;
            List<Book> newBooks = new List<Book>();
            foreach (var book in books)
            {
                newBooks.Add(book);
            }
            return newBooks;
        }
        public List<Tuple<Author,int>> GetTuples()
        {
            var authors = from book in this.books
                          from author in book.authors
                          group author by new
                          {
                              author.FirstName,
                              author.LastName,
                          } into g
                          select new
                          {
                              firstName = g.Key.FirstName,
                              lastName = g.Key.LastName,
                              Count = g.Count()
                          };
            List<Tuple<Author, int>> listTuples = new List<Tuple<Author, int>>();
            foreach (var author in authors)
            {
                listTuples.Add(new Tuple<Author, int>(new Author(author.firstName, author.lastName), author.Count));
            }
            return listTuples;
        }
        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();
            foreach (var book in books)
            {
                outputString.Append(book.ToString() + "\n");
            }
            return outputString.ToString();
        }
    }
}
