using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DTO
{
    public class Document
    {
        public int Id { get; set; }
        public DocStatus Status { get; set; }
        public string Url { get; set; }
        public string FileExtension { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public enum DocStatus
    {
        [Description("UNDER REVIEW")]
        UNDERREVIEW = 0,
        [Description("VALIDATED")]
        VALIDATED = 1,
        [Description("REJECTED")]
        REJECTED = 2,
    }
}
