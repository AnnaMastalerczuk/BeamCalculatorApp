using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models.BeamInfo
{
    public class BeamData
    {
        public int CantileverLeft { get; set; }
        public int CantileverRight { get; set; }
        public int SpanOne { get; set; }

        public BeamData(int cantileferL, int cantileverR, int span)
        {
            this.CantileverLeft = cantileferL;
            this.CantileverRight = cantileverR;
            this.SpanOne = span;            
        }



    }
}
