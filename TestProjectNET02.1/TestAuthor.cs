using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02._1;
using System;

namespace TestProjectNET02._1
{
    [TestClass]
    public class TestAuthor
    {
        [ExpectedException(typeof(Exception), "Exception was not thrown")]
        [TestMethod]
        public void CreateAuthor_WithWrongName_ExcentionReturned()
        {
            Author author = new Author("", "Shupyk");
        }
    }
}
