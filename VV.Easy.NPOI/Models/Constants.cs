using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VV.Easy.NPOI.Models
{
    public static class Constants
    {
        public static class BuiltInTypes
        {
            public readonly static Type Boolean = typeof(Boolean);

            public readonly static Type NullableBoolean = typeof(Nullable<Boolean>);


            public readonly static Type Byte = typeof(Byte);

            public readonly static Type NullableByte = typeof(Nullable<Byte>);


            public readonly static Type SByte = typeof(SByte);

            public readonly static Type NullableSByte = typeof(Nullable<SByte>);


            public readonly static Type Decimal = typeof(Decimal);

            public readonly static Type NullableDecimal = typeof(Nullable<Decimal>);


            public readonly static Type Double = typeof(Double);

            public readonly static Type NullableDouble = typeof(Nullable<Double>);


            public readonly static Type Float = typeof(Single);

            public readonly static Type NullableFloat = typeof(Nullable<Single>);


            public readonly static Type Int = typeof(Int32);

            public readonly static Type NullableInt = typeof(Nullable<Int32>);


            public readonly static Type UInt = typeof(UInt32);

            public readonly static Type NullableUInt = typeof(Nullable<UInt32>);


            public readonly static Type Long = typeof(Int64);

            public readonly static Type NullableLong = typeof(Nullable<Int64>);


            public readonly static Type ULong = typeof(UInt64);

            public readonly static Type NullableULong = typeof(Nullable<UInt64>);


            public readonly static Type Short = typeof(Int16);

            public readonly static Type NullableShort = typeof(Nullable<Int16>);


            public readonly static Type UShort = typeof(UInt16);

            public readonly static Type NullableUShort = typeof(Nullable<UInt16>);


            public readonly static Type DateTime = typeof(DateTime);

            public readonly static Type NullableDateTime = typeof(Nullable<DateTime>);


            public readonly static Type Char = typeof(Char);

            public readonly static Type String = typeof(String);
        }


        public static class Regexs
        {
            public static readonly Regex RegNumber = new Regex(@"^\d+$", RegexOptions.Compiled);

            public static readonly Regex RegNumberSign = new Regex(@"^[+-]?\d+$", RegexOptions.Compiled);

            public static readonly Regex RegDecimal = new Regex(@"^\d+(\.?\d+)?$", RegexOptions.Compiled);

            public static readonly Regex RegDecimalSign = new Regex(@"[+-]?\d+(\.?\d+)?$", RegexOptions.Compiled);

            // 时间，中文，Email，手机.....
        }


        public static class Delimiter
        {
            public static string HtmlLineBreak { get; } = "<br />";

            public static string WinLineBreak { get; } = "\r\n";

            public static string LinuxLineBreak { get; } = "\n";
        }
    }
}
