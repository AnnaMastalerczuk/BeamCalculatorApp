using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models.BeamInfo
{
    public class Load
    {
        public int StartPosition { get; set; }
        public double LoadValue { get; set; }

        public Load(int startPosition, double loadValue)
        {
            this.StartPosition = startPosition;
            this.LoadValue = loadValue;
        }

        public Load()
        {
            
        }

    }
}
