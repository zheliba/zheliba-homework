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

            var user1 = new User()
            {
                Name = "Vasya",
                Birthday = "694216800",
                RegistrationDate = "1633507337",
                PhoneNumber = "0993238462",
                Culture = "en-US",
                Sum = 1000.01m
            };
            var user2 = new User()
            {
                Name = "Lyoha",
                Birthday = "970840052",
                RegistrationDate = "1572788922",
                PhoneNumber = "0973223462",
                Culture = "uk-UA",
                Sum = 2000.14m
            };

            var userRepository = new ListRepository<User>();
            //userRepository.Add(user1);
            //userRepository.Add(user2);
            //Console.WriteLine(userRepository.GetById(2).Culture);

            var temp = userRepository.GetAll();
            foreach (var item in temp)
            {
                Console.WriteLine(item.Name);
            }
 
            Console.ReadKey();
        }
    }
}
