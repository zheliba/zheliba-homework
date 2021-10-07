using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Strings.Common;


namespace Strings.BL
{
    public class Program
    {
        static void Main()
        {
            string pathToUsers = @"..\Data.json";
            string pathToAccounts = @"..\Accounts.json";


            var user1 = new User()
            {
                UserId = 1,
                Name = "Vasya",
                Birthday = "694216800",
                RegistrationDate = "1633507337",
                PhoneNumber = "0993238462",
                Culture = "en-US"
            };
            var user2 = new User()
            {
                UserId = 2,
                Name = "Lyoha",
                Birthday = "970840052",
                RegistrationDate = "1572788922",
                PhoneNumber = "0973223462",
                Culture = "uk-UA"
            };

            //using (StreamWriter userData = new(pathToUsers, true))
            //{
            //    userData.WriteLine(JsonConvert.SerializeObject(user1));
            //    userData.WriteLine(JsonConvert.SerializeObject(user2));
            //}


            Console.WriteLine(user1.Birthday.UnixToDateTimeConvert(user1.Culture));
            Console.ReadKey();
        }
    }
}
