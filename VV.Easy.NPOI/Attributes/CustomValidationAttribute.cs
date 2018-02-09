using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(dynamic value)
        {
            throw new NotImplementedException();
        }
    }
}
