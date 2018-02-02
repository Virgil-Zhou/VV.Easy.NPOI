using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SheetAttribute : Attribute
    {
        public string SheetName { get; }

        public int TitleRowIndex { get; }


        public SheetAttribute(string sheetName) : this(sheetName, 0)
        {

        }

        public SheetAttribute(string sheetName, int titleRowIndex)
        {
            SheetName = sheetName;
            TitleRowIndex = titleRowIndex;
        }

    }
}
