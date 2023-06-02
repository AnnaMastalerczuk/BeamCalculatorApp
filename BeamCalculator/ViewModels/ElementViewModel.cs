using BeamCalculator.Commands;
using BeamCalculator.Models;
using BeamCalculator.Models.BeamInfo;
using BeamCalculator.Models.Loader;
using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace BeamCalculator.ViewModels
{
    public class ElementViewModel : Conductor<IScreen>, INotifyDataErrorInfo, INotifyPropertyChanged
    {

        private CalcTest _calcTest;

        //load lists

        private BindableCollection<LoadPoint> _listLoadPoint;
        public BindableCollection<LoadPoint> ListLoadPoint
        {
            get
            {
                return _listLoadPoint;
            }
            set
            {
                _listLoadPoint = value;
                NotifyOfPropertyChange(() => ListLoadPoint);

                if (ListLoadPoint[0].StartPosition > 10)
                {
                    AddError("Niepoprawny format. Podaj wymiary w mm", nameof(ListLoadPoint));
                }

            }   
        }

  

        //private string _startPosition;

        //public string StartPosition
        //{
        //    get { return _startPosition; }
        //    set { 
        //        _startPosition = value;
        //        NotifyOfPropertyChange(() => StartPosition);

        //        ClearErrors(nameof(StartPosition));
        //        if (StartPosition.Contains('.') || StartPosition.Contains(',') || StartPosition.Any(Char.IsLetter))
        //        {
        //            AddError("Niepoprawny format. Podaj wymiary w mm", nameof(StartPosition));
        //        }
        //    }
        //}



        private BindableCollection<LoadDistributed> _listLoadDistributed;
        public BindableCollection<LoadDistributed> ListLoadDistributed
        {
            get
            {
                return _listLoadDistributed;
            }
            set
            {
                _listLoadDistributed = value;
                NotifyOfPropertyChange(() => ListLoadDistributed);                
               
            }
        }


        //Category
        private List<Element> _listOfElements;
        public List<string> CategoryNames
        {
            get
            {
                return _listOfElements.Select(x => x.Category).Distinct().ToList();
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
                NotifyOfPropertyChange(() => ListOfElementsWithSelectedCategory);
            }
        }

        public List<Element> ListOfElementsWithSelectedCategory
        {
            get
            {
                if (SelectedCategory != null)
                {
                    return _listOfElements.Where(x => x.Category == SelectedCategory.ToString()).ToList();
                }
                //return _listOfElements.Where(x => x.Category == SelectedCategory.ToString()).ToList();
                return null;
            }
        }

        private Element _selectedElement;
        public Element SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                _selectedElement = value;
                NotifyOfPropertyChange(() => SelectedElement);
            }
        }

        //Dimensions
        private string _cantileverLeft;
        public string CantileverLeft
        {
            get
            {
                return _cantileverLeft;
            }
            set
            {
                _cantileverLeft = value;
                NotifyOfPropertyChange(() => CantileverLeft);
                NotifyOfPropertyChange(() => BeamLength);
                               
                ClearErrors(nameof(CantileverLeft));
                if(CantileverLeft.Contains('.') || CantileverLeft.Contains(',') || CantileverLeft.Any(Char.IsLetter))
                {
                    AddError("Niepoprawny format. Podaj wymiary w mm", nameof(CantileverLeft));                   
                } 
            }
        }

        private string _cantileverRight;
        public string CantileverRight
        {
            get
            {
                return _cantileverRight;
            }
            set
            {
                _cantileverRight = value;
                NotifyOfPropertyChange(() => CantileverRight);
                NotifyOfPropertyChange(() => BeamLength);

                ClearErrors(nameof(CantileverRight));
                if (CantileverRight.Contains('.') || CantileverRight.Contains(',') || CantileverRight.Any(Char.IsLetter))
                {
                    AddError("Niepoprawny format. Podaj wymiary w mm", nameof(CantileverRight));
                }
            }
        }

        private string _spanOne;
        public string SpanOne
        {
            get
            {
                return _spanOne;
            }
            set
            {
                _spanOne = value;
                NotifyOfPropertyChange(() => SpanOne);
                NotifyOfPropertyChange(() => BeamLength);

                ClearErrors(nameof(SpanOne));
                if (SpanOne.Contains('.') || SpanOne.Contains(',') || SpanOne.Any(Char.IsLetter))
                {
                    AddError("Niepoprawny format. Podaj wymiary w mm", nameof(SpanOne));
                }

            }
        }

        //private int _beamLength;

        //public int BeamLength
        //{
        //    get { return int.Parse(CantileverRight) + int.Parse(CantileverRight) + int.Parse(SpanOne); }

        //}

        private int _beamLength;

        public int BeamLength
        {
            get { return _beamLength; }
            set { _beamLength = value; }
        }




        //load list command

        private DelegateCommand<LoadPoint> _deleteLoadPointCommand;
        public DelegateCommand<LoadPoint> DeleteLoadPointCommand =>
            _deleteLoadPointCommand ?? (_deleteLoadPointCommand = new DelegateCommand<LoadPoint>(ExecuteDeleteLoadPointCommand));
        void ExecuteDeleteLoadPointCommand(LoadPoint parameter)
        {
            ListLoadPoint.Remove(parameter);

        }

        private DelegateCommand<LoadDistributed> _deleteLoadDistributedCommand;
        public DelegateCommand<LoadDistributed> DeleteLoadDistributedCommand =>
           _deleteLoadDistributedCommand ?? (_deleteLoadDistributedCommand = new DelegateCommand<LoadDistributed>(ExecuteDeleteLoadDistributedCommand));
        void ExecuteDeleteLoadDistributedCommand(LoadDistributed parameter)
        {
            ListLoadDistributed.Remove(parameter);

        }

        public ICommand GenerateChartsCommand { get; }



        public void GenerateChartsButton()
        {
            ActivateItemAsync(new ResultViewModel());

        }

        private readonly Dictionary<string, List<string>> _propertyNameToErrorsDictionary;

        public ElementViewModel()
        {
            GenerateChartsCommand = new GenerateChartsCommand(this);

            //_listOfElements = FileLoader.getElementsList();

            _calcTest = new CalcTest();
            ListLoadPoint = new BindableCollection<LoadPoint>()
            {
                {new LoadPoint(0,0) }

            };

            ListLoadDistributed = new BindableCollection<LoadDistributed>()
            {
                

            };

            _listOfElements = new List<Element>()
            {
                {new Element("belka", "belka drewniana", 5,10) },
                {new Element("belka lezaca", "belka drewniana", 1,7) },
                {new Element("rygiel ws", "rygiel stalowy", 25,100) },
                {new Element("rygiel mk", "rygiel stalowy", 35,150) }
            };

            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        bool INotifyDataErrorInfo.HasErrors => _propertyNameToErrorsDictionary.Any();

        IEnumerable INotifyDataErrorInfo.GetErrors(string? propertyName)
        {
            return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }

                private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }

            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);

            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrorsDictionary.Remove(propertyName);

            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        

    }
}
