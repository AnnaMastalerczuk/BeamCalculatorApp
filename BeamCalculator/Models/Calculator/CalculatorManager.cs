using BeamCalculator.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models.Calculator
{
    public class CalculatorManager
    {

        private CalculateReactionsOneSpan _calculateReactionsOneSpan;

        public CalculatorManager()
        {
            _calculateReactionsOneSpan = new CalculateReactionsOneSpan();
    
        }


        public void Calculate(Element element, BeamData beamData, List<LoadPoint> loadPoint, List<LoadDistributed> loadDistributed)
        {
            List<double> reactions = new List<double>();
            reactions = _calculateReactionsOneSpan.CalculateReactions(beamData, loadPoint, loadDistributed);
           

            
        }
    }
}
