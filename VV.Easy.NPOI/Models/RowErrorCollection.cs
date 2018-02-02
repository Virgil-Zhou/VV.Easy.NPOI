using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public class RowErrorCollection : Collection<RowError>
    {
        public void Add(string errorMessage)
        {
            Add(new RowError(errorMessage));
        }

        public void Add(Exception exception)
        {
            Add(new RowError(exception));
        }
    }
}
