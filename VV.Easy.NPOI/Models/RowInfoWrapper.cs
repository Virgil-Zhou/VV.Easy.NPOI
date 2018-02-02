using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public class RowInfoWrapper<T> where T : class, new()
    {
        private readonly int? _rowIndex;

        private readonly RowErrorDictionary _rowErrorDic;

        public RowInfoWrapper(int rowIndex, ColumnInfoDictionary colInfoDic)
        {
            _rowIndex = rowIndex;
            _rowErrorDic = new RowErrorDictionary(colInfoDic);
        }

        public int? RowIndex => _rowIndex;

        public T RowData { get; } = new T();

        public RowErrorDictionary RowErrorDic => _rowErrorDic;
    }
}
