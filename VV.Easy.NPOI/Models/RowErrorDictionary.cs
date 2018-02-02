using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public class RowErrorDictionary : IDictionary<string, RowErrorInfo>
    {
        private readonly ColumnInfoDictionary _colInfoDic;

        private readonly Dictionary<string, RowErrorInfo> _innerDictionary = new Dictionary<string, RowErrorInfo>();

        public RowErrorDictionary(ColumnInfoDictionary colInfoDic)
        {
            _colInfoDic = colInfoDic;
        }

        public RowErrorInfo this[string key]
        {
            get
            {
                RowErrorInfo value;
                _innerDictionary.TryGetValue(key, out value);
                return value;
            }
            set => _innerDictionary[key] = value;
        }

        public ICollection<string> Keys => _innerDictionary.Keys;

        public ICollection<RowErrorInfo> Values => _innerDictionary.Values;

        public int Count => _innerDictionary.Count;

        public bool IsValid => Values.All(c => c.Errors.Count == 0);

        public bool IsReadOnly => ((IDictionary<string, RowErrorInfo>)_innerDictionary).IsReadOnly;

        public void Add(string key, RowErrorInfo value) => _innerDictionary.Add(key, value);

        public void Add(KeyValuePair<string, RowErrorInfo> item) => ((IDictionary<string, RowErrorInfo>)_innerDictionary).Add(item);

        public void AddRowError(string key, Exception exception) => GetRowErrorForKey(key).Errors.Add(exception);

        public void AddRowError(string key, string errorMessage) => GetRowErrorForKey(key).Errors.Add(errorMessage);

        public RowErrorInfo GetRowErrorForKey(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            RowErrorInfo rowErrorInfo;
            if (!TryGetValue(key, out rowErrorInfo))
            {
                int? colIndex = null;
                if (_colInfoDic.ContainsKey(key))
                {
                    colIndex = _colInfoDic[key].ColumnIndex;
                }
                rowErrorInfo = new RowErrorInfo() { ColumnIndex = colIndex };
                this[key] = rowErrorInfo;
            }

            return rowErrorInfo;
        }

        public void Clear() => _innerDictionary.Clear();

        public bool Contains(KeyValuePair<string, RowErrorInfo> item) => ((IDictionary<string, RowErrorInfo>)_innerDictionary).Contains(item);

        public bool ContainsKey(string key) => _innerDictionary.ContainsKey(key);

        public void CopyTo(KeyValuePair<string, RowErrorInfo>[] array, int arrayIndex) => ((IDictionary<string, RowErrorInfo>)_innerDictionary).CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<string, RowErrorInfo>> GetEnumerator() => _innerDictionary.GetEnumerator();

        public bool Remove(string key) => _innerDictionary.Remove(key);

        public bool Remove(KeyValuePair<string, RowErrorInfo> item) => ((IDictionary<string, RowErrorInfo>)_innerDictionary).Remove(item);

        public bool TryGetValue(string key, out RowErrorInfo value) => _innerDictionary.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_innerDictionary).GetEnumerator();

        public string GetErrorMessage(string delimiter)
        {
            var strBuilder = new StringBuilder(200);
            var errorMsgList = _innerDictionary.Values.SelectMany(c => c.Errors.Select(p => p.ErrorMessage));

            return string.Join(delimiter, errorMsgList);
        }
    }
}
