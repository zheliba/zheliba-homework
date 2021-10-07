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
                Culture = new System.Globalization.CultureInfo("en-US", false)
            };
            var user2 = new User()
            {
                UserId = 2,
                Name = "Lyoha",
                Birthday = "970840052",
                RegistrationDate = "1572788922",
                PhoneNumber = "0973223462",
                Culture = new System.Globalization.CultureInfo("uk-UA", false)
            };

            //using (StreamWriter userData = new(path, true))
            //{
            //    userData.WriteLine(JsonConvert.SerializeObject(user1));
            //    userData.WriteLine(JsonConvert.SerializeObject(user2));
            //}

            Converter converter = new Converter();
            converter.GetInfoToConvert(user1);
            user1 = converter.ConvertToLocal(converter.Culture, user1);
            Console.WriteLine(user1.Birthday);
            Console.WriteLine(user1.Culture);

            converter.GetInfoToConvert(user2);
            user2 = converter.ConvertToLocal(converter.Culture, user2);
            Console.WriteLine(user2.Birthday);
            Console.WriteLine(user2.Culture);
            Console.ReadKey();
        }
    }
}
