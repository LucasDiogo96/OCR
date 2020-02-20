using System.Collections.Generic;

namespace Domain
{
    public class SpaceLine
    {
        public string LineText { get; set; }
        public List<SpaceWord> Words { get; set; }
        public decimal MaxHeight { get; set; }
        public decimal MinTop { get; set; }
    }
}
