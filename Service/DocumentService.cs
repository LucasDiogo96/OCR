using Domain;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DocumentService
    {

        OCRService service = new OCRService();

        public  void Process(List<Document> documents)
        {
            try
            {
                foreach (Document document in documents)
                {
                    ResponseOCR response = service.InitializeOCR(document);

                    //CompareBLL.ShowExtractedTests(response);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  void ProcessFile(Document document)
        {
            try
            {
                //ResponseOCR response = OCRService.InitializeOCR(document);

                //CompareBLL.ShowExtractedTests(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static bool CompareDeepProcess(ResponseOCR ocr, string ComparedValue)
        {
            foreach (SpaceParsedResult result in ocr.ParsedResults)
            {
                if (result.TextOverlay != null)
                    foreach (SpaceLine lines in result.TextOverlay.Lines)
                    {
                        foreach (var word in lines.Words)
                        {
                            if (word.WordText.Equals(ComparedValue))
                                return true;
                            else
                                return false;
                        }
                    }
            }
            return false;
        }
    }
}
