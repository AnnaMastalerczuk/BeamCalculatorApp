using BeamCalculator.Commands;
using BeamCalculator.Models;
using BeamCalculator.Models.BeamInfo;
using BeamCalculator.Models.Loader;
using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace BeamCalculator.ViewModels
{
    public class ElementViewModel : Conductor<IScreen>  
    {

        private CalcTest _calcTest;

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
            }
        }

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
            }
        }


        //load list - point load

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
        }

        public void GenerateChartsButton()
        {
            ActivateItemAsync(new ResultViewModel());

        }


        public string Nazwa;

        //generate charts
        //public void GenerateCharts()
        //{
            //_beamData.SpanOne = int.Parse(_spanOne);
            //_beamData.CantileverRight = int.Parse(_cantileverRight);
            //_beamData.CantileverLeft = int.Parse(_cantileverLeft);

            //Nazwa = _calcTest.GiveTestName2(_beamData);


        //}

        //public string ValueTest2
        //{
        //    get
        //    {
        //        _beamData.SpanOne = int.Parse(_spanOne);
        //        _beamData.CantileverRight = int.Parse(_cantileverRight);
        //        _beamData.CantileverLeft = int.Parse(_cantileverLeft);

        //        return _calcTest.GiveTestName2(_beamData);
        //    }
        //}


        //test
        public string ValueTest
        {
            get 
            {
                //return _calcTest.Calc(_beamData); 
                //return _calcTest.Calc(CantileverLeft, CantileverRight);
                //return _calcTest.GiveName(_selectedElement);
                return _calcTest.GiveTestName();
            }
        }


    }
}
