using System;
using System.Collections.Generic;
namespace Rejestr
{
    public class Tools
    {
        public static string UserInputText(string AppText)
        {
            while (true)
            {
                Console.Write(AppText);

                string userText = Console.ReadLine();

                if (string.IsNullOrEmpty(userText))
                {
                    Console.Clear();
                    Console.WriteLine("Nie wprowadzono żadnej wartości!");
                }
                else
                {
                    Console.Clear();
                    return userText;
                }
            }
        }

        public static int UserInputNum(string AppText)
        {
            while (true)
            {
                Console.Write(AppText);

                if (!int.TryParse(Console.ReadLine(), out int UserNum))
                {
                    Console.Clear();
                    Console.WriteLine("Należy wprowadzić wartość liczbową!");
                }
                else
                {
                    Console.Clear();
                    return UserNum;
                }
            }
        }

        public static bool VeriFier()
        {
            Random rnd = new Random();
            while (true)
            {
                int a = rnd.Next(0, 100);
                int b = rnd.Next(0, 100);

                int userAnswer= UserInputNum($"Wskaż wynik równania: {a} + {b}: ");
                if (userAnswer != a + b)
                {
                    Console.WriteLine("Błędna odpowiedź!");
                } else
                {
                    return true;
                }
            }
        }

        public static List<Person> LookupByName(List<Person> userList, string ofName)
        {
            List<Person> result = userList.FindAll(var => var.Name == ofName);
            return result;
        }
        public static List<Person> LookupBySurname(List<Person> userList, string ofSurame)
        {
            List<Person> result = userList.FindAll(var => var.Surname == ofSurame);
            return result;
        }
        public static List<Person> LookupByNameAndSurname(List<Person> userList, string ofName, string ofSurame)
        {
            List<Person> result = userList.FindAll(var => (var.Name == ofName) && (var.Surname == ofSurame));
            return result;
        }
        public static List<Person> LookupByAge(List<Person> userList, int ofAge)
        {
            List<Person> result = userList.FindAll(var => var.Age == ofAge);
            return result;
        }
    }
}
