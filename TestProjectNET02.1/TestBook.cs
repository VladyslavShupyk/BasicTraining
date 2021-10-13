using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02._1;
using System;

namespace TestProjectNET02._1
{
    [TestClass]
    public class TestBook
    {
        [TestMethod]
        public void Equals_Book1AndBook2_TrueReturned()
        {
            //Arrange

            Book book1 = new Book("CLR VIA C#", "555-5-55-555555-5");
            Book book2 = new Book("C# ASP.NET Core", "555-5-55-555555-5");
            bool expected = true;
            //Action

            bool actual = book1.Equals(book2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Equals_Book1AndBook2_FalseReturned()
        {
            //Arrange

            Book book1 = new Book("CLR VIA C#", "555-5-55-555555-5");
            Book book2 = new Book("C# ASP.NET Core", "555-5-55-555555-6");
            bool expected = false;
            //Action

            bool actual = book1.Equals(book2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [ExpectedException(typeof(Exception),"Exception was not thrown")]
        [TestMethod]
        public void CreateBookWithWrongIsbn_ExceptionReturned()
        {
            Book book = new Book("C#", "333-3-33-333333-33");
        }
    }
}
