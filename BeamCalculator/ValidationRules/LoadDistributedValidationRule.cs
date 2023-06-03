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
    public class LoadDistributedValidationRule : ValidationRule
    {
        public BeamLengthWrapper BeamLengthWrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            LoadDistributed? loadDistributed = ((BindingGroup)value).Items[0] as LoadDistributed;
            if ((loadDistributed.StartPosition + loadDistributed.EndPosition) > this.BeamLengthWrapper.BeamLength)
            {
                return new ValidationResult(false,
                    "Przekracza długośc belki");
            }
            else
            {
                return ValidationResult.ValidResult;
            }

        }
    }
}
