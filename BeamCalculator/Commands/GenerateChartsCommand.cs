using BeamCalculator.Models;
using BeamCalculator.Models.BeamInfo;
using BeamCalculator.Models.Calculator;
using BeamCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeamCalculator.Commands
{
    public class GenerateChartsCommand : CommandBase
    {
        private readonly CalculatorManager _calculatorManager;
        private readonly ElementViewModel _elementViewModel;

        public GenerateChartsCommand(ElementViewModel elementViewModel)
        {
            _calculatorManager = new CalculatorManager();
            _elementViewModel = elementViewModel;
            _elementViewModel.PropertyChanged += OnViewModelPropertyChanged;
           
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ElementViewModel.SelectedElement) || e.PropertyName == nameof(ElementViewModel.SpanOne)
                || e.PropertyName == nameof(ElementViewModel.CantileverLeft) || e.PropertyName == nameof(ElementViewModel.CantileverRight))
            {
                OnCanExecutedChanged();                        
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return _elementViewModel.SelectedElement != null && !string.IsNullOrEmpty(_elementViewModel.SpanOne) 
                && !string.IsNullOrEmpty(_elementViewModel.CantileverLeft) && !string.IsNullOrEmpty(_elementViewModel.CantileverRight)
                && base.CanExecute(parameter);

        }
        public override void Execute(object? parameter)
        {
            List<LoadPoint> loadPoint = _elementViewModel.ListLoadPoint.ToList();
            List<LoadDistributed> loadDistributed = _elementViewModel.ListLoadDistributed.ToList();
            Element element = _elementViewModel.SelectedElement;
            BeamData beamData = new BeamData(int.Parse(_elementViewModel.CantileverLeft), int.Parse(_elementViewModel.CantileverRight), int.Parse(_elementViewModel.SpanOne));

            try
            {

                _calculatorManager.Calculate(element, beamData, loadPoint, loadDistributed);            

            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd. Podaj dane ponownie");
            }            
        }
    }
}
