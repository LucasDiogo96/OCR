using System;
using System.Collections.Generic;
using System.Text;
    
namespace DTO
{
    public class SpaceLine
    {
        public string LineText { get; set; }
        public List<SpaceWord> Words { get; set; }
        public decimal MaxHeight { get; set; }
        public decimal MinTop { get; set; }
    }
}
