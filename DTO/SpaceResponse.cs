using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ResponseOCR
    {
        public List<SpaceParsedResult> ParsedResults { get; set; }
        public int OCRExitCode { get; set; }
        public bool IsErroredOnProcessing { get; set; }
        public List<string> ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public string ProcessingTimeInMilliseconds { get; set; }
        public string SearchablePDFURL { get; set; }
    }
}