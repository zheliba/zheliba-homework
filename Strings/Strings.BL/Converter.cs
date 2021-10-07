using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings.BL
{
    public class Converter
    {
        public CultureInfo Culture { get; set; }
        public string? Birthday { get; set; }
        public string RegistrationDate { get; set; }
        public void GetInfoToConvert(User user)
        {
            Culture = user.Culture;
            Birthday = user.Birthday;
            RegistrationDate = user.RegistrationDate;
        }


        public User ConvertToLocal(IFormatProvider formatProvider, User user)
        {
            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }
            var unixTimeStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var birthdayLocal = unixTimeStart.AddSeconds(Convert.ToDouble(user.Birthday)).ToLocalTime();
            var registrationDateLocal = unixTimeStart.AddSeconds(Convert.ToDouble(user.RegistrationDate)).ToLocalTime();
            user.Birthday = birthdayLocal.ToString(user.Culture);
            user.RegistrationDate = registrationDateLocal.ToString(user.Culture);

            return user;
        }
    }
}
