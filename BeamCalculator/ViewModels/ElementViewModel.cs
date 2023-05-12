using BeamCalculator.Models;
using BeamCalculator.Models.BeamInfo;
using BeamCalculator.Models.Loader;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.ViewModels
{
    public class ElementViewModel : Screen
    {
        private List<Element> _listOfElements;
        private BeamData _beamData;
        private CalcTest _calcTest;

        private string _selectedCategory;
        private Element _selectedElement;

        public ElementViewModel()
        {
            //_listOfElements = FileLoader.getElementsList();
            _beamData = new BeamData();
            _calcTest = new CalcTest(); 

            _listOfElements = new List<Element>()
            {
                {new Element("belka", "belka drewniana", 5,10) },
                {new Element("belka lezaca", "belka drewniana", 1,7) },
                {new Element("rygiel ws", "rygiel stalowy", 25,100) },
                {new Element("rygiel mk", "rygiel stalowy", 35,150) }
            };
        }

        public List<string> CategoryNames
        {
            get
            {
                return _listOfElements.Select(x => x.Category).Distinct().ToList();
            }
        }

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

        public Element SelectedElement
        {
            get { return _selectedElement; }
            set
            {
                _selectedElement = value;
                NotifyOfPropertyChange(() => SelectedElement);
            }
        }

        public string CantileverLeft
        {
            get
            {
                return _beamData.CantileverLeft.ToString();
            }
            set
            {
                _beamData.CantileverLeft = int.Parse(value);
                NotifyOfPropertyChange(() => CantileverLeft);
            }
        }

        public string CantileverRight
        {
            get
            {
                return _beamData.CantileverRight.ToString();
            }
            set
            {
                _beamData.CantileverRight = int.Parse(value);
                NotifyOfPropertyChange(() => CantileverRight);
            }
        }

        public string SpanOne
        {
            get
            {
                return _beamData.SpanOne.ToString();
            }
            set
            {
                _beamData.SpanOne = int.Parse(value);
                NotifyOfPropertyChange(() => SpanOne);
            }
        }

        public string ValueTest
        {
            get 
            {
                //return _calcTest.Calc(_beamData); 
                return _calcTest.Calc(CantileverLeft, CantileverRight);
            }
        }


    }
}
