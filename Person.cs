using System;
using System.Collections.Generic;

namespace Rejestr
{
    public class Person: IsAdult, IsReady
    {
        const string Undefined = "UNDEFINED_VALUE";

        private string name;
        private string surname;
        private int age;
        private string sex;

        public string Name
        {
            get => name;
            set { name = value; }
        }

        public string Surname
        {
            get; set;
        }

        public string Sex
        {
            get => sex;
            set { sex = value; }
        }

        public int Age
        {
            get => age;
            set { age = value; }
        }

        public Person()
        {
            name = Undefined;
            age = -10;
            sex = Undefined;
            surname = Undefined;
        }

        public Person(string imie, string nazwisko, string płeć, int wiek)
        {
            this.Name = imie;
            this.Age = wiek;
            this.Sex = płeć;
            this.Surname = nazwisko;
        }

        public override string ToString()
        {
            return $"Imie:{Name} Nazwisko:{Surname} Płeć:{Sex} Wiek:{Age}";
        }

        public bool IsReady()
        {
            if (name != Undefined && age != -10 && sex != Undefined && surname != Undefined)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

        public bool IsAdult()
        {
            if (Age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            };
        }

    }
}
