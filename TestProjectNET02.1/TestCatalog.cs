using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02._1;
using System.Collections.Generic;

namespace TestProjectNET02._1
{
    [TestClass]
    public class TestCatalog
    {
        static Catalog catalog;
        [ClassInitialize]
        public static void InitializeCurrentTest(TestContext testContext)
        {
            catalog = new Catalog();
            catalog.Add(new Book("CLR VIA C#", "333-3-33-333333-3", new Author("Vladyslav", "Shupyk")));
            catalog.Add(new Book("ASP.NET Core", "444-4-44-444444-4", new Author("Evgen", "Shupyk")));
            catalog.Add(new Book("ASP.NET MVC", "555-5-55-555555-5", new Author("Svetlana", "Shupyk")));
        }
        [TestMethod]
        public void GetBooksByAuthorNameAndSurname_Catalog1AndCatalog2_TrueReturned()
        {
            //Avarage
            List<Book> books1 = new List<Book>();
            books1.Add(new Book("CLR VIA C#", "333-3-33-333333-3", new Author("Vladyslav", "Shupyk")));
            string str2 = books1.ToString();
            //Action
            List<Book> books2 = catalog.GetBooksByAuthorNameAndSurname("Vladyslav", "Shupyk");
            string str1 = books2.ToString();
            bool actual = false;
            if (str1 == str2)
                actual = true;

            //Assert
            Assert.IsTrue(actual);
        }

    }
}
