using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;

namespace BeamCalculator.Models
{
    public class ElementMap : ClassMap<Element>
    {
        //public ElementMap() 
        //{
        //    Map(m => m.Name).Name(nameof(Element.Name));
        //    Map(m => m.Category).Name(nameof(Element.Category));
        //    Map(m => m.MaxM).Name(nameof(Element.MaxM));
        //    Map(m => m.MaxT).Name(nameof(Element.MaxT));
        //}


    }
}
