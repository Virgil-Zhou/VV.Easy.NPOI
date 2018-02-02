using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Models;

namespace VV.Easy.NPOI
{
    public static class NpoiAdapter
    {
        public static List<RowInfoWrapper<T>> Reader<T>(this Stream stream) where T : class, new()
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            return WorkbookFactory.Create(stream).Mapper<T>(0);
        }


    }
}
