using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using System.Diagnostics;

namespace lab_40b_microsoft_office
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

            Process.Start("WINWORD.EXE", fileName);
        }
    }
}
