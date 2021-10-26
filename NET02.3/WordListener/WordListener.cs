using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using NET02._3;
using System;
using System.IO;
using System.IO.Packaging;

namespace WordListener
{
    public class WordListener : IListener
    {
        const string DEFAULT_PATH = "WordListenerLog.txt";
        public NET02._3.Level Level { get; set; } = NET02._3.Level.DEBUG;
        public string Path { get; set; } = DEFAULT_PATH;

        public WordListener() { }
        public void Write(string message, NET02._3.Level level)
        {
            if (level <= Level)
            {
                if(!File.Exists(Path))
                {
                    Package package = Package.Open(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(package, WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document(
                            new Body(
                                new Paragraph(
                                    new Run(
                                        new Text(DateTime.Now + "|" + level.ToString() + "|" + message)))));
                    }
                }
                else
                {
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(Path, true))
                    {
                        MainDocumentPart mainPart = wordDocument.MainDocumentPart;
                        mainPart.Document.Body.AppendChild(new Paragraph(new Run(new Text(DateTime.Now + "|" + level.ToString() + "|" + message))));
                    }
                }
            }
        }
    }
}
