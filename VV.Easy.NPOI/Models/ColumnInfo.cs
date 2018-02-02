using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Attributes;

namespace VV.Easy.NPOI.Models
{
    public class ColumnInfo
    {
        public int? ColumnIndex { get; internal set; }

        public ColumnAttribute ColumnAttr { get; internal set; }
    }
}
