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
        public string Culture { get; set; }
        public string? Birthday { get; set; }
        public string RegistrationDate { get; set; }
        public void GetInfoToConvert(User user)
        {
            Culture = user.Culture;
            Birthday = user.Birthday;
            RegistrationDate = user.RegistrationDate;
        }


    }
}
