using DTO;
using System;

namespace BLL
{
    public class CompareBLL
    {
        public static void ShowExtractedTests(ResponseOCR ocr)

        {
            foreach(var x in ocr.ParsedResults)
            {
                Console.WriteLine(x.ParsedText);
            }
        }
        public static bool CompareDeepProcess(ResponseOCR ocr, string ComparedValue)
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
        public static bool CompareSimpleProcess(string ExtractedText, string ComparedValue)
        {

            LibraryBLL.RemoveSpecialCharacters(ref ExtractedText);

            if (ExtractedText.Contains(ComparedValue))
                return true;

            return false;
        }
    }
}
