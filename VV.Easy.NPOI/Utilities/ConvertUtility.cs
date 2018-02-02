using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Utilities
{
    public static class ConvertUtility
    {
        public static dynamic ConvertTo(dynamic value, Type type)
        {
            if (value == null)
            {
                return null;
            }

            if (!type.IsGenericType)
            {
                return Convert.ChangeType(value, type);
            }

            var genericTypeDefinition = type.GetGenericTypeDefinition();
            if (genericTypeDefinition == typeof(Nullable<>))
            {
                return Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
            }

            throw new InvalidCastException(string.Format("Invalid cast from type \"{0}\" to type \"{1}\".", value.GetType().FullName, type.FullName));
        }
    }
}
