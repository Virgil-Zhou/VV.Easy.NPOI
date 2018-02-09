using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RangeAttribute : ValidationAttribute
    {
        private dynamic _minimum;
        private dynamic _maximum;
        private Func<dynamic, dynamic> _conversion;

        public RangeAttribute(int minimum, int maximum)
        {
            Initialize(minimum, maximum, v => Convert.ToInt32(v));
        }

        public RangeAttribute(double minimum, double maximum)
        {
            Initialize(minimum, maximum, v => Convert.ToDouble(v));
        }

        public RangeAttribute(string minimum, string maximum)
        {
            Initialize(minimum, maximum, v => Convert.ToString(v));
        }

        private void Initialize(dynamic minimum, dynamic maximum, Func<dynamic, dynamic> conversion)
        {
            _minimum = minimum;
            _maximum = maximum;
            _conversion = conversion;
        }


        public override bool IsValid(dynamic value)
        {
            // 如果值为null，则验证通过，应使用非空验证判断。
            if (value == null) return true;

            dynamic convertedValue;

            try
            {
                convertedValue = _conversion(value);
            }
            catch (Exception)
            {
                return false;
            }

            return _minimum.CompareTo(convertedValue) <= 0 && _maximum.CompareTo(convertedValue) >= 0;
        }

    }
}
