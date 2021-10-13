using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET02._1
{
    public class Catalog : IEnumerable
    {
        public List<Book> books;
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
            }
        }
        #endregion
        public void Add(Book book)
        {
            books.Add(book);
        }
        public void Remove(Book book)
        {
            books.Remove(book);
        }
        public IEnumerator GetEnumerator()
        {
            foreach(var book in books.OrderBy(b => b.Name))
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
            return books.ToList();
        }
        public List<Book> GetBooksByDateSortedDescending()
        {
            var books = from book in this.books
                        orderby book.Date descending
                        select book;
            return books.ToList();
        }
        public List<Tuple<Author,int>> GetAuthorsBooksCounts()
        {
            var authors = from book in this.books
                          from author in book.authors
                          group author by new { author.FirstName, author.LastName } into g
                          select new Tuple<Author, int>(new Author(g.Key.FirstName, g.Key.LastName), g.Count());
            return authors.ToList();
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
