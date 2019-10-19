using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class OcrBLL
    {
        public static void Process(List<Document> documents)
        {
            try
            {
                foreach (Document document in documents)
                {
                    ResponseOCR response = LibraryBLL.InitializeOCR(document);

                    CompareBLL.ShowExtractedTests(response);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ProcessFile(Document document)
        {
            try
            {
                ResponseOCR response = LibraryBLL.InitializeOCR(document);

                CompareBLL.ShowExtractedTests(response);
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
