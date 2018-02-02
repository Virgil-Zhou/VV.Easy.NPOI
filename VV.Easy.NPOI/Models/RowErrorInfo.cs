using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public class RowErrorInfo
    {
        public int? ColumnIndex { get; internal set; }

        public RowErrorCollection Errors { get; } = new RowErrorCollection();
    }
}
