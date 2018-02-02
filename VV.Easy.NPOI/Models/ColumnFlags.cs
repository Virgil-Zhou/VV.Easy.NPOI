using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public enum ColumnFlags
    {
        ColOptional = 1,

        ColRequired = 2,

        ValRequired = 4,

        NotNullOrWhiteSpace = 8,
    }
}
