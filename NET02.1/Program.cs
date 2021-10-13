using System;
using System.Collections.Generic;
using System.Threading;

namespace NET02._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Clr Via C#", "123-4-56-789123-1", new Author("Vladyslav", "Shupyk"), DateTime.Now);
            Thread.Sleep(1000);
            Book book2 = new Book("C# Lanhuage", "123-4-56-789123-2", new Author("Svetlana", "Shupyk"), DateTime.Now);
            Thread.Sleep(1000);
            book2.authors.Add(new Author("Vladyslav", "Shupyk"));
            Book book3 = new Book("ASP.NET CORE", "123-4-56-789123-3", new Author("Evgen", "Shupyk"), DateTime.Now);
            Thread.Sleep(1000);
            Book book4 = new Book("ASP.NET MVC", "123-4-56-789123-4", new Author("Julia", "Fedoseeinko"), DateTime.Now);
            book4.authors.Add(new Author("Vladyslav", "Shupyk"));
            book4.authors.Add(new Author("Evgen", "Shupyk"));
            Catalog catalog = new Catalog();
            catalog.Add(book);
            catalog.Add(book2);
            catalog.Add(book3);
            catalog.Add(book4);
            Console.WriteLine(catalog.ToString());
            Console.WriteLine("Checking books for equality : ");
            if (book.Equals(book))
                Console.WriteLine("Books are the same");
            else
                Console.WriteLine("Books are not the same");
            if (book.Equals(book2))
                Console.WriteLine("Books are the same");
            else
                Console.WriteLine("Books are not the same");
            Console.WriteLine();
            Console.WriteLine("Show tuple of Author - count of books : ");
            List<Tuple<Author, int>> tuple = catalog.GetAuthorsBooksCounts();
            foreach (var item in tuple)
                Console.WriteLine(item.Item1.FirstName + " " + item.Item1.LastName + " - " + item.Item2 + " book");
            Console.WriteLine();
            Console.WriteLine("List of books in catalog : ");
            foreach (Book item in catalog)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Show books sorted by date descending : ");
            List<Book> catalogWithDateByDescending = catalog.GetBooksByDateSortedDescending();
            foreach(var item in catalogWithDateByDescending)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Show books by Firstname and Lastname author : ");
            List<Book> catalogWithAuthor = catalog.GetBooksByAuthorNameAndSurname("Vladyslav", "Shupyk");
            foreach(var item in catalogWithAuthor)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Show catalog sort by name using enumeration : ");
            foreach (Book Book in catalog)
                Console.WriteLine(Book.Name);
            Console.WriteLine();
            try
            {
                Book findBook = catalog["123-4-56-789123-1"];
                Console.WriteLine("Show finded book by ISBN : ");
                Console.WriteLine(findBook.ToString());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
