using System;
using System.Globalization;

namespace Strings.Common
{
    public static class StringHandler
    {
        public static string UnixToDateTimeConvert(this string unixTime, string format)
        {
            if (format == null)
            {
                format = "en-US";
            }
            IFormatProvider formatProvider = CultureInfo.CreateSpecificCulture(format);
            var unixTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var result = unixTimeStart.AddSeconds(Convert.ToDouble(unixTime)).ToLocalTime().ToString(formatProvider);

            return result;
        }
        
    }
}
