using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeamCalculator.ViewModels
{
    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty BeamLengthProperty =
        DependencyProperty.Register("BeamLength", typeof(int),
        typeof(Wrapper), new FrameworkPropertyMetadata(int.MaxValue));

        public int BeamLength
        {
            get { return (int)GetValue(BeamLengthProperty); }
            set { SetValue(BeamLengthProperty, value); }
        }
    }
}
