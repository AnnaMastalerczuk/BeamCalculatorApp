using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamCalculator.Models
{
    public class Element
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double MaxM { get; set; }
        public double MaxT { get; set; }

        //public Element(string Name, string Category, double MaxM, double MaxT) 
        //{
        //    this.Name = Name;
        //    this.Category = Category;
        //    this.MaxM = MaxM;
        //    this.MaxT = MaxT;            
        //}

    }
}
