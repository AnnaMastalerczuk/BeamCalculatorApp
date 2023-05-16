using BeamCalculator.Models.Calculator;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.ViewModels
{
    public class ResultViewModel : Screen
    {
        private CalculateForcesOneSpan _calcualtorForcesOneSpan;

        public BindableCollection<Point> PointListOfTForces { get; }

        public ResultViewModel()
        {
            _calcualtorForcesOneSpan = new CalculateForcesOneSpan();
            PointListOfTForces = new BindableCollection<Point>(_calcualtorForcesOneSpan.ListOfPointsT);
        }


	}
}
