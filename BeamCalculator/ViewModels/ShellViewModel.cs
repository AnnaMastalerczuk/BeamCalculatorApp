using BeamCalculator.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using BeamCalculator.Views;
using System.Windows.Controls.Primitives;
using System.Collections;
using BeamCalculator.Models.Loader;

namespace BeamCalculator.ViewModels
{
    public class ShellViewModel : Conductor<IScreen>  
    {  
        public ShellViewModel() 
        {
            //ActivateItemAsync(new ElementViewModel());

        }

        public void BeamOneSpan()
        {
            ActivateItemAsync(new ElementViewModel());
        }


    }
}
