using BeamCalculator.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace BeamCalculator.ViewModels
{
    public class CourseValidationRule : ValidationRule
    {
        public int BeamLength { get; set; }
       // private Wrapper wrapper = new Wrapper();
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //string text = value.ToString();
            //int age;
            //int.TryParse(text, out age);
            //if (age < 1 || age > 10)
            //    return new ValidationResult(false, "Invalid age.");

            //return ValidationResult.ValidResult;

            LoadPoint? loadPoint = ((BindingGroup)value).Items[0] as LoadPoint;
            if (loadPoint.StartPosition > 100)
            {

                return new ValidationResult(false,
                    "Wieksze niz 100");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }


}
