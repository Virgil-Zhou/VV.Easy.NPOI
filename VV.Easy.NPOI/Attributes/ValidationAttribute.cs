using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Attributes
{
    public abstract class ValidationAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        private string _errorMessage;

        public abstract bool IsValid(dynamic value);
    }
}
