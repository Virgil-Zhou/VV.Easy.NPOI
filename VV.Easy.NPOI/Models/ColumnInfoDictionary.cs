using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Attributes;

namespace VV.Easy.NPOI.Models
{
    public class ColumnInfoDictionary : IDictionary<string, ColumnInfo>
    {
        private readonly Dictionary<string, ColumnInfo> _innerDictionary = new Dictionary<string, ColumnInfo>();

        public ColumnInfo this[string key]
        {
            get
            {
                ColumnInfo value;
                _innerDictionary.TryGetValue(key, out value);
                return value;
            }
            set => _innerDictionary[key] = value;
        }

        public ICollection<string> Keys => _innerDictionary.Keys;

        public ICollection<ColumnInfo> Values => _innerDictionary.Values;

        public int Count => _innerDictionary.Count;

        public bool IsReadOnly => ((IDictionary<string, ColumnInfo>)_innerDictionary).IsReadOnly;

        public void Add(string key, ColumnInfo value) => _innerDictionary.Add(key, value);

        public void Add(KeyValuePair<string, ColumnInfo> item) => ((IDictionary<string, ColumnInfo>)_innerDictionary).Add(item);

        public void AddColumnInfo(string key, int colIndex, ColumnAttribute colAttrObj)
        {
            var colInfo = GetColumnInfoForKey(key);

            colInfo.ColumnIndex = colIndex;
            colInfo.ColumnAttr = colAttrObj;
        }

        public ColumnInfo GetColumnInfoForKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            ColumnInfo colInfo;
            if (!TryGetValue(key, out colInfo))
            {
                colInfo = new ColumnInfo();
                this[key] = colInfo;
            }

            return colInfo;
        }

        public void Clear() => _innerDictionary.Clear();

        public bool Contains(KeyValuePair<string, ColumnInfo> item) => ((IDictionary<string, ColumnInfo>)_innerDictionary).Contains(item);

        public bool ContainsKey(string key) => _innerDictionary.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, ColumnInfo>[] array, int arrayIndex) => ((IDictionary<string, ColumnInfo>)_innerDictionary).CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<string, ColumnInfo>> GetEnumerator() => _innerDictionary.GetEnumerator();

        public bool Remove(string key) => _innerDictionary.Remove(key);

        public bool Remove(KeyValuePair<string, ColumnInfo> item) => ((IDictionary<string, ColumnInfo>)_innerDictionary).Remove(item);

        public bool TryGetValue(string key, out ColumnInfo value) => _innerDictionary.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_innerDictionary).GetEnumerator();
    }
}
