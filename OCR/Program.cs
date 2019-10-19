using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace OCR
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] bytes = File.ReadAllBytes(@"c:\Files\example.jpg");
            string text = Convert.ToBase64String(bytes);

            Document document = new Document();
            document.Content = text;

            OcrBLL.ProcessFile(document);

            Console.ReadKey();
        }
    }
}


