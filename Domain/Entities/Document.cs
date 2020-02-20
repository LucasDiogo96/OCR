using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain
{
    public class Document
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string FileExtension { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
