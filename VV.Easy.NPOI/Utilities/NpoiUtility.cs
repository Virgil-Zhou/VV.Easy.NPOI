using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Models;
using static System.String;
using System.Reflection;
using VV.Easy.NPOI.Attributes;
using NPOI.HSSF.Util;

namespace VV.Easy.NPOI.Utilities
{
    public static class NpoiUtility
    {
        internal static dynamic GetCellValue(this ICell cell, IWorkbook workbook)
        {
            if (cell == null) return null;

            switch (cell.CellType)
            {
                case CellType.Numeric:
                    if (HSSFDateUtil.IsCellDateFormatted(cell))
                    {
                        return cell.DateCellValue;
                    }
                    return cell.NumericCellValue;

                case CellType.String:
                    return cell.StringCellValue;

                case CellType.Boolean:
                    return cell.BooleanCellValue;

                case CellType.Error:
                    return cell.ErrorCellValue;

                case CellType.Formula:
                    if (workbook is HSSFWorkbook)
                    {
                        var hssfCell = new HSSFFormulaEvaluator(workbook).EvaluateInCell(cell);
                        return GetCellValue(hssfCell, workbook);
                    }
                    var xssfCell = new XSSFFormulaEvaluator(workbook).EvaluateInCell(cell);
                    return GetCellValue(xssfCell, workbook);

                case CellType.Blank:
                    return "";

                case CellType.Unknown:
                default:
                    return cell.ToString();
            }
        }


        internal static bool IsEmptyRow(this IRow row, int columnCount)
        {
            if (row == null) return true;

            for (int i = 0; i < columnCount; i++)
            {
                var cell = row.GetCell(i);
                if (cell != null && cell.CellType != CellType.Blank)
                {
                    return false;
                }
            }

            return true;
        }


        internal static (bool, string) CheckUniquenessOfColumn(this IRow titleRow)
        {
            if (titleRow == null)
                throw new ArgumentNullException(nameof(titleRow));

            var msg = "";
            var list = new List<string>(100);
            for (int i = 0; i < titleRow.LastCellNum; i++)
            {
                var cell = titleRow.GetCell(i);
                if (cell == null) continue;

                var value = cell.StringCellValue.Trim();
                if (IsNullOrWhiteSpace(value)) continue;

                if (list.Contains(value))
                {
                    msg += $"列（{value}）重复。";
                }
                else
                {
                    list.Add(value);
                }
            }

            return (msg == "", msg);
        }


        public static void RetentionInvalidateData<T>(this IWorkbook workbook, int index, List<RowInfoWrapper<T>> rowInfoWrapperList, bool isIncludeValidData = true) where T : class, new()
        {
            if (workbook == null)
                throw new ArgumentNullException(nameof(workbook));

            var sheet = workbook.GetSheetAt(index);
            if (sheet == null)
            {
                throw new ArgumentException($"不存在索引为：{index} 的工作表！");
            }

            var targetType = typeof(T);
            var sheetAttrObj = targetType.GetCustomAttribute<SheetAttribute>();
            if (sheetAttrObj == null)
            {
                throw new TargetException($"类型：{targetType.FullName} 上必须要有特性：{typeof(SheetAttribute).FullName} !");
            }

            if (sheetAttrObj.SheetName != sheet.SheetName)
            {
                throw new TargetException($"类型：{targetType.FullName} 与工作表（{sheet.SheetName}）不相符！");
            }

            var titleRow = sheet.GetRow(sheetAttrObj.TitleRowIndex);
            if (titleRow == null)
            {
                throw new ArgumentException($"不存在行索引为：{sheetAttrObj.TitleRowIndex} 的标题行！");
            }

            if (isIncludeValidData)
            {
                rowInfoWrapperList = rowInfoWrapperList.GetInvalidData();
            }

            var rowIndexList = rowInfoWrapperList.Select(c => c.RowIndex);
            for (int ri = sheet.LastRowNum; ri >= sheetAttrObj.TitleRowIndex + 1; ri--)
            {
                if (rowIndexList.Contains(ri))
                {
                    var row = sheet.GetRow(ri);
                    var rowInfo = rowInfoWrapperList.First(c => c.RowIndex == ri);
                    var colIndexList = rowInfo.RowErrorDic.Values.Select(c => c.ColumnIndex);
                    foreach (var colIndex in colIndexList)
                    {
                        if (!colIndex.HasValue) continue;
                        var cell = row.GetCell(colIndex.Value);
                        if (cell == null) continue;

                        var cellStyle = workbook.CreateCellStyle();
                        cellStyle.FillForegroundColor = HSSFColor.Red.Index;
                        cellStyle.FillPattern = FillPattern.SolidForeground;
                        cell.CellStyle = cellStyle;
                    }
                }
                else
                {
                    var endRow = ri == sheet.LastRowNum ? ri + 1 : sheet.LastRowNum;
                    sheet.ShiftRows(ri + 1, endRow, -1);
                }
            }
        }

    }
}
