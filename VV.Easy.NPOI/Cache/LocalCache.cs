using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Reflection;
using VV.Easy.NPOI.Models;

namespace VV.Easy.NPOI.Cache
{
    public static class LocalCache
    {

        internal static readonly ConcurrentDictionary<string, IEnumerable<PropertyInfo>> KeyProperties = new ConcurrentDictionary<string, IEnumerable<PropertyInfo>>();

        internal static IEnumerable<PropertyInfo> GetProperties(this Type targetType, string key)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            IEnumerable<PropertyInfo> properties;
            if (!KeyProperties.TryGetValue(key, out properties))
            {
                properties = targetType.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
            }

            return properties;
        }

    }
}
