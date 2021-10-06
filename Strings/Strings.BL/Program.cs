using System;
using System.IO;
using Newtonsoft.Json;

namespace Strings.BL
{
    public class Program
    {
        static void Main()
        {
            string path = @"D:\projects\Mentorship2021\Strings\Data.json";

            var user1 = new User()
            {
                UserId = 1,
                Name = "Vasya",
                Birthday = "694216800",
                RegistrationDate = "1633507337",
                PhoneNumber = "0993238462",
                Culture = "US"
            };
            var user2 = new User()
            {
                UserId = 2,
                Name = "Lyoha",
                Birthday = "970840052",
                RegistrationDate = "1572788922",
                PhoneNumber = "0973223462",
                Culture = "UA"
            };
                     
            using (StreamWriter userData = new(path, true))
            {
                userData.WriteLine(JsonConvert.SerializeObject(user1));
                userData.WriteLine(JsonConvert.SerializeObject(user2));
            }

        }
    }
}
