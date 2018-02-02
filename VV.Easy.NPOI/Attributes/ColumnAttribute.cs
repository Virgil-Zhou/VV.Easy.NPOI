using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using VV.Easy.NPOI.Models;

namespace VV.Easy.NPOI.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string titleName) : this(titleName, ColumnFlags.ColRequired)
        {

        }

        public ColumnAttribute(string titleName, ColumnFlags colFlags)
        {
            TitleName = titleName;
            ColumnFlags = colFlags;
        }

        public string TitleName { get; }

        public ColumnFlags ColumnFlags { get; }

    }
}
