using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SpaceTextOverlay
    {
        public List<SpaceLine> Lines { get; set; }
        public bool HasOverlay { get; set; }
        public string Message { get; set; }
    }
}

