using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Attributes;
using VV.Easy.NPOI.Cache;
using VV.Easy.NPOI.Models;

namespace VV.Easy.NPOI.Utilities
{
    public static class TypeUtility
    {
        internal static ColumnInfoDictionary GetColumnInfo(this Type targetType, IRow titleRow)
        {
            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            if (titleRow == null)
                throw new ArgumentNullException(nameof(titleRow));

            var colInfoDic = new ColumnInfoDictionary();
            var properties = targetType.GetProperties(targetType.FullName) as List<PropertyInfo>;

            for (int i = properties.Count - 1; i >= 0; i--)
            {
                var propInfo = properties[i];
                var colAttrObj = propInfo.GetCustomAttribute<ColumnAttribute>();
                if (colAttrObj == null)
                {
                    properties.RemoveAt(i);
                    continue;
                }

                for (int ci = 0; ci < titleRow.LastCellNum; ci++)
                {
                    var cell = titleRow.GetCell(ci);
                    if (cell == null) continue;

                    var titleName = cell.StringCellValue.Trim();
                    if (colAttrObj.TitleName == titleName)
                    {
                        colInfoDic.AddColumnInfo(propInfo.Name, ci, colAttrObj);
                        break;
                    }
                }
            }

            if (!LocalCache.KeyProperties.ContainsKey(targetType.FullName))
            {
                LocalCache.KeyProperties.TryAdd(targetType.FullName, properties);
            }

            return colInfoDic;
        }


        internal static (bool, string) Check(this ICell cell, Type targetType, IWorkbook workbook)
        {
            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            if (targetType == null)
                throw new ArgumentNullException(nameof(targetType));

            var value = cell.GetCellValue(workbook).ToString();

            var success = (true, "");
            var failed = (false, $"值：“{value}” 不能被转换成：{targetType.FullName} 类型。");
            if (targetType == Constants.BuiltInTypes.String || targetType == Constants.BuiltInTypes.Char)
            {
                return success;
            }

            // 浮点型
            if (targetType == Constants.BuiltInTypes.Decimal || targetType == Constants.BuiltInTypes.Double || targetType == Constants.BuiltInTypes.Float ||
                targetType == Constants.BuiltInTypes.NullableDecimal || targetType == Constants.BuiltInTypes.NullableDouble || targetType == Constants.BuiltInTypes.NullableFloat)
            {
                if (!Constants.Regexs.RegDecimalSign.IsMatch(value))
                {
                    return failed;
                }

                return success;
            }

            // 有符号整形
            if (targetType == Constants.BuiltInTypes.Int || targetType == Constants.BuiltInTypes.Long || targetType == Constants.BuiltInTypes.Short || targetType == Constants.BuiltInTypes.SByte ||
                targetType == Constants.BuiltInTypes.NullableInt || targetType == Constants.BuiltInTypes.NullableLong || targetType == Constants.BuiltInTypes.NullableShort || targetType == Constants.BuiltInTypes.NullableSByte)
            {
                if (!Constants.Regexs.RegNumberSign.IsMatch(value))
                {
                    return failed;
                }

                return success;
            }

            // Boolean类型
            if (targetType == Constants.BuiltInTypes.Boolean || targetType == Constants.BuiltInTypes.NullableBoolean)
            {
                if (value == "0" || value == "1")
                {
                    return success;
                }

                return failed;
            }

            // DateTime类型
            if (targetType == Constants.BuiltInTypes.DateTime || targetType == Constants.BuiltInTypes.NullableDateTime)
            {
                DateTime result;
                if (DateTime.TryParse(value, out result))
                {
                    return success;
                }

                return failed;
            }

            // 无符号整形
            if (targetType == Constants.BuiltInTypes.UInt || targetType == Constants.BuiltInTypes.ULong || targetType == Constants.BuiltInTypes.UShort || targetType == Constants.BuiltInTypes.Byte ||
                targetType == Constants.BuiltInTypes.NullableUInt || targetType == Constants.BuiltInTypes.NullableULong || targetType == Constants.BuiltInTypes.NullableUShort || targetType == Constants.BuiltInTypes.NullableByte)
            {
                if (!Constants.Regexs.RegNumber.IsMatch(value))
                {
                    return failed;
                }

                return success;
            }

            throw new InvalidValidationException($"无效的验证类型：{targetType.FullName}");
        }
    }
}
