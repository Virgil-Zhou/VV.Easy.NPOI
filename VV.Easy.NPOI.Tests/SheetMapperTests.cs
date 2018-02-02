using Microsoft.VisualStudio.TestTools.UnitTesting;
using VV.Easy.NPOI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.SS.UserModel;
using VV.Easy.NPOI.Tests.Models;
using VV.Easy.NPOI.Utilities;
using VV.Easy.NPOI.Models;

namespace VV.Easy.NPOI.Tests
{
    [TestClass()]
    public class SheetMapperTests
    {
        [TestMethod()]
        public void MapperTest()
        {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(directory, "侨金所资产导入012401.xlsx");
            var fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            var workbook = WorkbookFactory.Create(fs);
            var readList = workbook.Mapper<QJS_OriginalProjectImport>("资产信息");

            //var count = readList.Count(c => !c.RowErrorDic.IsValid);
            //Assert.IsTrue(count == 3);


            //var errorMsg = readList[1].RowErrorDic.GetErrorMessage("");
            //Assert.IsTrue(errorMsg.Contains("发行机构"));


            //workbook.RetentionInvalidateData(0, readList);
            //using (var ms = new MemoryStream())
            //{
            //    workbook.Write(ms);
            //    var buffer = ms.ToArray();
            //    using (var fsw = new FileStream(@"D:\123.xlsx", FileMode.Create, FileAccess.Write))
            //    {
            //        fsw.Write(buffer, 0, buffer.Length);
            //        fsw.Flush();
            //    }
            //}
            //var msg = readList.GetErrorMessage(Constants.Delimiter.WinLineBreak);
            //Assert.IsTrue(msg != "");
        }
    }
}