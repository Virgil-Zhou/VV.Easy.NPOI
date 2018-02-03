using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Attributes;
using VV.Easy.NPOI.Models;
using VV.Easy.NPOI.Utilities;
using VV.Easy.NPOI.Cache;
using static System.String;

namespace VV.Easy.NPOI
{
    public static class SheetMapper
    {
        public static List<RowInfoWrapper<T>> Mapper<T>(this IWorkbook workbook, string name) where T : class, new()
        {
            if (workbook == null)
                throw new ArgumentNullException(nameof(workbook));

            if (IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var index = workbook.GetSheetIndex(name);

            return workbook.Mapper<T>(index);
        }


        public static List<RowInfoWrapper<T>> Mapper<T>(this IWorkbook workbook, int index) where T : class, new()
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

            var (unique, message) = titleRow.CheckUniquenessOfColumn();
            if (!unique)
            {
                throw new Exception(message);
            }

            var result = new List<RowInfoWrapper<T>>();
            var colInfoDic = targetType.GetColumnInfo(titleRow);
            var columnList = targetType.GetProperties(targetType.FullName);

            for (int ri = sheetAttrObj.TitleRowIndex + 1; ri <= sheet.LastRowNum; ri++)
            {
                var row = sheet.GetRow(ri);
                if (row == null) continue;
                if (row.IsEmptyRow(titleRow.LastCellNum)) continue;

                var rowInfoWrapper = new RowInfoWrapper<T>(ri, colInfoDic);
                foreach (var col in columnList)
                {
                    try
                    {
                        var colInfo = colInfoDic[col.Name];

                        if ((colInfo.ColumnAttr.ColumnFlags & ColumnFlags.ColRequired) == ColumnFlags.ColRequired || (colInfo.ColumnAttr.ColumnFlags & ColumnFlags.ValRequired) == ColumnFlags.ValRequired)
                        {
                            if (!colInfo.ColumnIndex.HasValue)
                            {
                                rowInfoWrapper.RowErrorDic.AddRowError(col.Name, $"工作表（{sheet.SheetName}），第 {ri + 1} 行，列名 “{colInfo.ColumnAttr.TitleName}” 不存在。");
                                continue;
                            }
                        }

                        var cell = row.GetCell(colInfo.ColumnIndex.Value);
                        var value = cell.GetCellValue(workbook);

                        if ((colInfo.ColumnAttr.ColumnFlags & ColumnFlags.ValRequired) == ColumnFlags.ValRequired)
                        {
                            if (value == null)
                            {
                                rowInfoWrapper.RowErrorDic.AddRowError(col.Name, $"工作表（{sheet.SheetName}），第 {ri + 1} 行，列名 “{colInfo.ColumnAttr.TitleName}” 不能为空。");
                                continue;
                            }
                        }

                        if ((colInfo.ColumnAttr.ColumnFlags & ColumnFlags.NotNullOrWhiteSpace) == ColumnFlags.NotNullOrWhiteSpace)
                        {
                            if (IsNullOrWhiteSpace(value?.ToString()))
                            {
                                rowInfoWrapper.RowErrorDic.AddRowError(col.Name, $"工作表（{sheet.SheetName}），第 {ri + 1} 行，列名 “{colInfo.ColumnAttr.TitleName}” 不能为空。");
                                continue;
                            }
                        }

                        var (CheckResult, ErrorMsg) = cell.Check(col.PropertyType, workbook);
                        if (!CheckResult)
                        {
                            rowInfoWrapper.RowErrorDic.AddRowError(col.Name, $"工作表（{sheet.SheetName}），第 {ri + 1} 行，列名 “{colInfo.ColumnAttr.TitleName}” {ErrorMsg}");
                            continue;
                        }

                        var propVal = ConvertUtility.ConvertTo(value, col.PropertyType);

                        col.SetValue(rowInfoWrapper.RowData, propVal);
                    }
                    catch (Exception ex)
                    {
                        rowInfoWrapper.RowErrorDic.AddRowError(col.Name, ex);
                    }
                }

                result.Add(rowInfoWrapper);
            }

            return result;
        }

    }
}
