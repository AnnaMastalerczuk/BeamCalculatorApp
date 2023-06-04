using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CsvHelper;
using CsvHelper.Configuration;

namespace BeamCalculator.Models.Loader
{
    public class FileLoader
    {
        public List<Element> getElementsList()
        {
            //List<Element> list = new List<Element>();
            //list.Add(new Element("Dźwigarek", "Timber beams", 5, 10));
            //list.Add(new Element("Podwójny  dwigarek", "Timber beams", 10, 20));
            //list.Add(new Element("Rygiel WS100", "Steel wallers", 15, 100));
            //list.Add(new Element("Rygiel WS200", "Steel wallers", 15, 100));

            //return list;

            string csvPath = @"D:\Ania\Z dysku H\KURS PROGRAMOWANIA\C#\kurs_c#\BeamCalculatorApp\resources\elementsList.csv";
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // csv.Context.RegisterClassMap<ElementMap>();
                var records = csv.GetRecords<Element>().ToList();
                return records;
            }
        }
    }
}
