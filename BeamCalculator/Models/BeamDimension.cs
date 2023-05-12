using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models
{
    public class BeamDimension
    {
        public int CantileverLeft { get; set; } = 0;
        public int CantileverRight { get; set; } = 0;

        public Dictionary<string, int> SpanDimensionsList { get; set; } = new Dictionary<string, int>()
        {
            { "spanOne", 0 },
            { "spanTwo", 0 },
            { "spanThree", 0 },
            { "spanFour", 0 },
            { "spanFive", 0 }
        };
        public int SpanOne { get; set; } = 0;
        public int SpanTwo { get; set; } = 0;
        public int SpanThree { get; set; } = 0;
        public int SpanFour { get; set; } = 0;
        public int SpanFive { get; set; } = 0;
    }
}
