using System.Globalization;

namespace Strings.BL
{
    public class User : EntityBase
    {

        public string Name { get; set; }
        public string Birthday { get; set; }
        public string RegistrationDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Culture { get; set; }
        public decimal Sum { get; set; }

    }
}
