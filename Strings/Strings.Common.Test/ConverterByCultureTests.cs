using System;
using Xunit;
using Strings.Common;
using Strings.BL;

namespace Strings.Common.Test
{
    public class ConverterByCultureTests
    {
        [Theory]
        [InlineData("0", "en-US", "1/1/1970 2:00:00 AM")]
        [InlineData("-1", "en-US", "1/1/1970 1:59:59 AM")]
        [InlineData("970840052", "uk-UA", "06.10.2000 16:47:32")]
        [InlineData("-1", "uk-UA", "01.01.1970 01:59:59")]
        [InlineData("970840052", "nb-NO", "06.10.2000 16:47:32")]
        [InlineData("970840052", "zh-CN", "2000/10/6 下午4:47:32")]
        [InlineData("970840052", "en-GB", "06/10/2000 16:47:32")]
        [InlineData("970840052", "sv-SE", "2000-10-06 16:47:32")]

        public void UnixToUsualConvert_Valid_ShouldWork(string unixTime, string format, string expected)
        {
            string actual = unixTime.UnixToUsualConvert(format);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, "en-US", "unixTime")]
        [InlineData("", "en-US", "unixTime")]
        [InlineData("asdasdas", "en-US", "unixTime")]
        public void UnixToUsualConvert_InvalidParameters_ShouldThrowEx(string unixTime, string format, string param)
        {
            Assert.Throws<ArgumentException>(param, () => unixTime.UnixToUsualConvert(format));
        }


        [Theory]
        [InlineData("0", null, "1/1/1970 2:00:00 AM")]
        [InlineData("0", "", "1/1/1970 2:00:00 AM")]
        public void UnixToUsualConvert_Invalid_ShouldWork(string unixTime, string format, string expected)
        {
            string actual = unixTime.UnixToUsualConvert(format);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(1040.11, "en-US", "1040.11")]
        [InlineData(3060.24, "uk-UA", "3060,24")]
        [InlineData(-2333.4444, "uk-UA", "-2333,4444")]
        [InlineData(-3060.24, "nb-NO", "−3060,24")]
        [InlineData(-30323260.2444456789, "zh-CN", "-30323260.2444457")]
        [InlineData(-30323260.2444456, "en-GB", "-30323260.2444456")]
        [InlineData(-30323260.2444456, "sv-SE", "−30323260,2444456")]

        public void ToLocalizedString_ValidArguments_ShouldWork(decimal sum, string format, string expected)
        {
            string actual = sum.ToLocalizedString(format);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-2333.4444, null, "-2333.4444")]
        public void ToLocalizedString_InvalidArguments_ShouldWork(decimal sum, string format, string expected)
        {
            string actual = sum.ToLocalizedString(format);

            Assert.Equal(expected, actual);
        }
    }
}
