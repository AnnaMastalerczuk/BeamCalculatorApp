using BeamCalculator.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models
{
    public class CalcTest
    {
        public string Calc(BeamData beamData)
        {
            string value = null;

            return value = (beamData.CantileverLeft + beamData.CantileverRight).ToString();

        }
        public string Calc(string val1, string val2)
        {
            string value = null;

            return value = (val1 + val2);

        }

        public string GiveName(Element element)
        {
            return element.Name;
        }

        public string GiveTestName()
        {
            return "Ania";
        }

        public string GiveTestName2(BeamData data)
        {
            return data.SpanOne.ToString();

        }

    }
}
