using System;
using System.Globalization;


namespace Strings.Common
{
    public static class ConverterByCulture
    {
        public static string UnixToUsualConvert(this string unixTime, string format)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "en-US";
            }
            IFormatProvider formatProvider = CultureInfo.CreateSpecificCulture(format);
            var unixTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            var success = double.TryParse(unixTime, out double doubleTime);
            if (!success) throw new ArgumentException("Wrong data", nameof(unixTime));

           
            var result = unixTimeStart.AddSeconds(doubleTime).ToLocalTime().ToString(formatProvider);
            return result;
        }
        
        public static string ToLocalizedString(this decimal sum, string format)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "en-US";
            }
            IFormatProvider formatProvider = CultureInfo.CreateSpecificCulture(format);
            var result = sum.ToString(formatProvider);
            return result;
        }
    }
}
