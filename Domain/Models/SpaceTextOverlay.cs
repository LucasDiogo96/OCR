using System.Collections.Generic;

namespace Domain
{
    public class SpaceTextOverlay
    {
        public List<SpaceLine> Lines { get; set; }
        public bool HasOverlay { get; set; }
        public string Message { get; set; }
    }
}

