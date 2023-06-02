using BeamCalculator.Models.BeamInfo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace BeamCalculator.ValidationRules
{
    public class LoadPointValidationRule : ValidationRule
    {

        public int BeamLength { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            LoadPoint? loadPoint = ((BindingGroup)value).Items[0] as LoadPoint;
            if (loadPoint.StartPosition > this.BeamLength)
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
