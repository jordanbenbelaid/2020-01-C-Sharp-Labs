using System;
using System.Diagnostics;
using Xceed.Words.NET;

namespace lab_40_microsoft_office
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "MicrosoftWordReport.docx";

            var doc = DocX.Create(fileName);

            doc.InsertParagraph("This is a Microsoft Word report");
            
            doc.InsertParagraph("This contains test report data");
            
            doc.InsertParagraph("5 tests have passed, 2 have failed");

            doc.Save();

            Process.Start(@"C:\Program Files(x86)\Microsoft Office\root\Office16\WINWORD.EXE", fileName);
        }
    }
}
