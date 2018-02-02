using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Models;

namespace VV.Easy.NPOI.Utilities
{
    public static class RowInfoWrapperUtility
    {
        public static List<RowInfoWrapper<T>> GetValidData<T>(this IEnumerable<RowInfoWrapper<T>> rowInfoWrapperList) where T : class, new()
        {
            if (rowInfoWrapperList == null) return null;

            return rowInfoWrapperList.Where(c => c.RowErrorDic.IsValid).ToList();
        }


        public static List<T> GetValidRawData<T>(this IEnumerable<RowInfoWrapper<T>> rowInfoWrapperList) where T : class, new()
        {
            if (rowInfoWrapperList == null) return null;

            return rowInfoWrapperList.Where(c => c.RowErrorDic.IsValid).Select(c => c.RowData).ToList();
        }


        public static List<RowInfoWrapper<T>> GetInvalidData<T>(this IEnumerable<RowInfoWrapper<T>> rowInfoWrapperList) where T : class, new()
        {
            if (rowInfoWrapperList == null) return null;

            return rowInfoWrapperList.Where(c => !c.RowErrorDic.IsValid).ToList();
        }


        public static List<T> GetInvalidRawData<T>(this IEnumerable<RowInfoWrapper<T>> rowInfoWrapperList) where T : class, new()
        {
            if (rowInfoWrapperList == null) return null;

            return rowInfoWrapperList.Where(c => !c.RowErrorDic.IsValid).Select(c => c.RowData).ToList();
        }


        public static string GetErrorMessage<T>(this IEnumerable<RowInfoWrapper<T>> rowInfoWrapperList, string delimiter) where T : class, new()
        {
            if (rowInfoWrapperList == null) return "";

            var rowErrorMsgList = rowInfoWrapperList.Where(c => !c.RowErrorDic.IsValid).Select(c => c.RowErrorDic.GetErrorMessage(delimiter));

            return string.Join("", rowErrorMsgList);
        }
    }
}
