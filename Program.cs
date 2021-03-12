using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Rejestr
{

    class MainClass: Tools
    {
        public static List<Person> ListOfPeople = new List<Person>();

        public static void App()
        {
            //PRZYKŁADOWY REJESTR UŻYTKOWNIKÓW
            /*
            ListOfPeople.Add(new Person("A", "A", "m", 1));
            ListOfPeople.Add(new Person("C", "A", "m", 1));
            ListOfPeople.Add(new Person("B", "A", "m", 1));
            ListOfPeople.Add(new Person("A", "A", "m", 2));
            ListOfPeople.Add(new Person("D", "C", "m", 2));
            ListOfPeople.Add(new Person("C", "C", "m", 2));
            ListOfPeople.Add(new Person("D", "C", "m", 2));
            ListOfPeople.Add(new Person("D", "D", "m", 3));
            ListOfPeople.Add(new Person("E", "D", "m", 3));
            ListOfPeople.Add(new Person("A", "D", "m", 4));
            ListOfPeople.Add(new Person("E", "D", "m", 4));
            ListOfPeople.Add(new Person("D", "A", "m", 4));
            ListOfPeople.Add(new Person("C", "A", "m", 4));
            ListOfPeople.Add(new Person("C", "A", "m", 4));
            ListOfPeople.Add(new Person("E", "A", "m", 5));
            ListOfPeople.Add(new Person("A", "B", "m", 5));
            ListOfPeople.Add(new Person("E", "B", "m", 5));
            ListOfPeople.Add(new Person("C", "B", "m", 6));
            ListOfPeople.Add(new Person("C", "B", "m", 6));
            ListOfPeople.Add(new Person("D", "C", "m", 6));
            ListOfPeople.Add(new Person("D", "C", "m", 7));
            ListOfPeople.Add(new Person("C", "C", "m", 7));
            ListOfPeople.Add(new Person("E", "C", "m", 8));
            ListOfPeople.Add(new Person("B", "A", "m", 8));
            ListOfPeople.Add(new Person("B", "A", "m", 8));
            ListOfPeople.Add(new Person("A", "A", "m", 8));
            ListOfPeople.Add(new Person("A", "D", "m", 1));
            ListOfPeople.Add(new Person("C", "D", "m", 1));
            ListOfPeople.Add(new Person("B", "D", "m", 1));
            ListOfPeople.Add(new Person("A", "D", "m", 2));
            ListOfPeople.Add(new Person("D", "D", "m", 2));
            ListOfPeople.Add(new Person("C", "A", "m", 2));
            ListOfPeople.Add(new Person("D", "A", "m", 2));
            ListOfPeople.Add(new Person("D", "A", "m", 3));
            ListOfPeople.Add(new Person("E", "A", "m", 3));
            ListOfPeople.Add(new Person("A", "C", "m", 4));
            ListOfPeople.Add(new Person("E", "C", "m", 4));
            ListOfPeople.Add(new Person("D", "C", "m", 4));
            ListOfPeople.Add(new Person("C", "C", "m", 4));
            ListOfPeople.Add(new Person("C", "B", "m", 4));
            ListOfPeople.Add(new Person("E", "B", "m", 5));
            ListOfPeople.Add(new Person("A", "B", "m", 5));
            ListOfPeople.Add(new Person("E", "A", "m", 5));
            ListOfPeople.Add(new Person("C", "A", "m", 6));
            ListOfPeople.Add(new Person("C", "A", "m", 6));
            ListOfPeople.Add(new Person("D", "A", "m", 6));
            ListOfPeople.Add(new Person("D", "B", "m", 7));
            ListOfPeople.Add(new Person("C", "B", "m", 7));
            ListOfPeople.Add(new Person("E", "B", "m", 8));
            ListOfPeople.Add(new Person("B", "A", "m", 8));
            ListOfPeople.Add(new Person("B", "A", "m", 8));
            ListOfPeople.Add(new Person("A", "C", "m", 8));
            */


            while (true)
            {
                Console.WriteLine("===== REJESTR OSÓB ======");
                Console.WriteLine("==== Wybierz opcję ======");
                Console.WriteLine("1. Zrejestruj nową osobę");
                Console.WriteLine("2. Wyszukaj osobę");
                Console.WriteLine("3. Edycja danych osoby");
                Console.WriteLine("4. Przeglądaj rejestr");
                Console.WriteLine("5. Usuń dane z rejestru");
                Console.WriteLine("6. Importuj rejestr z XML");
                Console.WriteLine("7. Eksportuj rejestr do XML");
                Console.WriteLine("8. Zakończ program");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice < 1 || choice > 8)
                    {
                        Console.Clear();
                        Console.WriteLine("Wprowadzono błędny numer opcji - wybierz ponownie: ");
                    }
                    else
                    {
                        switch (choice)
                        {
                            case 1:
                                RegisterNew();
                                break;
                            case 2:
                                Lookup();
                                break;
                            case 3:
                                EditDetails();
                                break;
                            case 4:
                                Overview();
                                break;
                            case 5:
                                DeleteData();
                                break;
                            case 6:
                                DeserializeFromXML();
                                break;
                            case 7:
                                SerializeToXML();
                                break;
                            case 8:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wybierz ponownie");
                }

            }
        }

        private static void RegisterNew()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("== DODAWANIE NOWEJ OSOBY DO REJESTRU ==");
                string imie = UserInputText("Wprowadź imie nowej osoby: ");
                string nazwisko = UserInputText("Wprowadź nazwisko nowej osoby: ");
                string płeć = UserInputText("Wprowadź płeć nowej osoby [m - mężczyzna / k - kobieta]: ");
                bool go = true;
                while (go)
                {
                    switch (płeć)
                    {
                        case "k":
                            go = false;
                            break;
                        case "m":
                            go = false;
                            break;
                        default:
                            Console.WriteLine("Wprowadzono nieprawidłowe dane");
                            płeć = UserInputText("Wprowadź płeć nowej osoby [m - mężczyzna / k - kobieta]: ");
                            break;
                    }
                }
                int wiek = UserInputNum("Wprowadź wiek nowej osoby [0-130]: ");
                while(wiek <= 0 || wiek > 130)
                {
                    wiek = UserInputNum("Wprowadzono liczbę spoza zakresu - wprowadź ponownie wiek nowej osoby [0-130]: ");
                }
                ListOfPeople.Add(new Person(imie, nazwisko, płeć, wiek));


                Console.WriteLine("Nowa osoba została dodana - czy chcesz dodać kolejną osobę?[T/n]: ");
                string choice = Console.ReadLine();
                do
                {
                    switch (choice)
                    {
                        case "T":
                            Console.Clear();
                            break;
                        case "n":
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Wybierz ponownie - czy chcesz dodać kolejną osobę?[T/n]: ");
                            choice = Console.ReadLine();
                            break;
                    }
                } while(choice != "T");
            }
        }

        private static void Lookup()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("== WYSZUKIWANIE OSOBY W REJESTRZE ==");
                if (ListOfPeople.Count <= 0)
                {
                    Console.WriteLine("Rejestr jest pusty");
                    Console.WriteLine("Wciśnij dowolny przycisk aby powrócić");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                Console.WriteLine("Wyszukaj osobę po:");
                Console.WriteLine("1. imieniu");
                Console.WriteLine("2. nazwisku");
                Console.WriteLine("3. wieku");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice < 1 || choice > 3)
                    {
                        Console.WriteLine("Wprowadzono błędny numer opcji - wybierz ponownie: ");
                    }
                    else
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Clear();
                                while (true)
                                {
                                    string imie = UserInputText("Wprowadź imie szukanej osoby: ");
                                    List<Person> resultname = LookupByName(ListOfPeople, imie);
                                    if(resultname.Count > 0)
                                    {
                                        Console.WriteLine("W rejestrze odnaleziono osoby: ");
                                        foreach (var osoba in resultname)
                                        {
                                            Console.WriteLine(osoba.ToString());
                                        }
                                        Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                                        string decision = Console.ReadLine();
                                        do
                                        {
                                            switch (decision)
                                            {
                                                case "T":
                                                    Console.Clear();
                                                    break;
                                                case "n":
                                                    Console.Clear();
                                                    return;
                                                default:
                                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                                    decision = Console.ReadLine();
                                                    break;
                                            }

                                        } while (decision != "T");

                                    } else
                                    {
                                        Console.WriteLine("W rejestrze nie znaleziono osoby ze wskazanym imieniem");
                                        Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                                        string decision = Console.ReadLine();
                                        do
                                        {
                                            switch (decision)
                                            {
                                                case "T":
                                                    Console.Clear();
                                                    break;
                                                case "n":
                                                    Console.Clear();
                                                    return;
                                                default:
                                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                                    decision = Console.ReadLine();
                                                    break;
                                            }

                                        } while (decision != "T");
                                    }
                                }
                            case 2:
                                Console.Clear();
                                while (true)
                                {
                                    string nazwisko = UserInputText("Wprowadź nazwisko szukanej osoby: ");
                                    List<Person> resultsurname = LookupBySurname(ListOfPeople, nazwisko);
                                    if (resultsurname.Count > 0)
                                    {
                                        Console.WriteLine("W rejestrze odnaleziono osoby: ");
                                        foreach (var osoba in resultsurname)
                                        {
                                            Console.WriteLine(osoba.ToString());
                                        }
                                        Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                                        string decision = Console.ReadLine();
                                        do
                                        {
                                            switch (decision)
                                            {
                                                case "T":
                                                    Console.Clear();
                                                    break;
                                                case "n":
                                                    Console.Clear();
                                                    return;
                                                default:
                                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                                    decision = Console.ReadLine();
                                                    break;
                                            }

                                        } while (decision != "T");

                                    }
                                    else
                                    {
                                        Console.WriteLine("W rejestrze nie znaleziono osoby ze wskazanym nazwiskiem");
                                        Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                                        string decision = Console.ReadLine();
                                        do
                                        {
                                            switch (decision)
                                            {
                                                case "T":
                                                    Console.Clear();
                                                    break;
                                                case "n":
                                                    Console.Clear();
                                                    return;
                                                default:
                                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                                    decision = Console.ReadLine();
                                                    break;
                                            }

                                        } while (decision != "T");
                                    }
                                }
                            case 3:
                                Console.Clear();
                                while (true)
                                {
                                    int age = UserInputNum("Wprowadź wiek szukanej osoby: ");
                                    List<Person> resultage = LookupByAge(ListOfPeople, age);
                                    if (resultage.Count > 0)
                                    {
                                        Console.WriteLine("W rejestrze odnaleziono osoby: ");
                                        foreach (var osoba in resultage)
                                        {
                                            Console.WriteLine(osoba.ToString());
                                        }
                                        Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                                        string decision = Console.ReadLine();
                                        do
                                        {
                                            switch (decision)
                                            {
                                                case "T":
                                                    Console.Clear();
                                                    break;
                                                case "n":
                                                    Console.Clear();
                                                    return;
                                                default:
                                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                                    decision = Console.ReadLine();
                                                    break;
                                            }

                                        } while (decision != "T");

                                    }
                                    else
                                    {
                                        Console.WriteLine("W rejestrze nie znaleziono osoby o wskazanym wieku");
                                        Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                                        string decision = Console.ReadLine();
                                        do
                                        {
                                            switch (decision)
                                            {
                                                case "T":
                                                    Console.Clear();
                                                    break;
                                                case "n":
                                                    Console.Clear();
                                                    return;
                                                default:
                                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                                    decision = Console.ReadLine();
                                                    break;
                                            }

                                        } while (decision != "T");
                                    }
                                }
                            default:
                                Console.WriteLine("Wybierz opcję ponownie: ");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Wybierz ponownie: ");
                }

            }

        }

        private static void EditDetails()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("== EDYCJA DANYCH W REJESTRZE ==");
                if (ListOfPeople.Count <= 0)
                {
                    Console.WriteLine("Rejestr jest pusty");
                    Console.WriteLine("Wciśnij dowolny przycisk aby powrócić");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                string imie = UserInputText("Wprowadź imie osoby z rejestru, której dane chcesz edytować: ");
                string nazwisko = UserInputText("Wprowadź nazwisko osoby z rejestru, której dane chcesz edytować: ");
                List<Person> result = LookupByNameAndSurname(ListOfPeople, imie, nazwisko);
                if (result.Count <= 0)
                {
                    Console.WriteLine("W rejestrze nie znaleziono wpisu zawierającego wskazane dane");
                    Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                    string decision = Console.ReadLine();
                    do
                    {
                        switch (decision)
                        {
                            case "T":
                                Console.Clear();
                                break;
                            case "n":
                                Console.Clear();
                                return;
                            default:
                                Console.Clear();
                                Console.WriteLine("Wybierz ponownie [T/n]:");
                                decision = Console.ReadLine();
                                break;
                        }

                    } while (decision != "T");
                }
                else
                {
                    Console.WriteLine($"Odnaleziono {result.Count} wpisów w rejestrze:");
                    foreach (var record in result)
                    {
                        Console.WriteLine($"{ListOfPeople.IndexOf(record)}. {record}");
                    }
                    int indexToEdit = UserInputNum("Podaj numer wpisu do edycji:");

                    while (indexToEdit > ListOfPeople.Count || indexToEdit < 0 || !ListOfPeople[indexToEdit].IsReady())
                    {
                        foreach (var record in result)
                        {
                            Console.WriteLine($"{ListOfPeople.IndexOf(record)}. {record}");
                        }
                        indexToEdit = UserInputNum("Wprowadzono błedy numer wpisu - wprowadź numer ponownie: ");
                    }

                    Console.WriteLine(ListOfPeople[indexToEdit].ToString());
                    Console.WriteLine("Wybierz pole do edycji:");
                    Console.WriteLine("1. Imie");
                    Console.WriteLine("2. Nazwisko");
                    Console.WriteLine("3. Wiek");
                    Console.WriteLine("4. Płeć");
                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        if (choice < 1 || choice > 4)
                        {
                            Console.WriteLine("Wprowadzono błędny numer opcji - wybierz ponownie: ");
                        }
                        else
                        {
                            switch (choice)
                            {
                                case 1:
                                    string newName = UserInputText("Wprowadź nowe imie osoby: ");
                                    ListOfPeople[indexToEdit].Name = newName;
                                    break;
                                case 2:
                                    string newSurname = UserInputText("Wprowadź nowe nazwisko osoby: ");
                                    ListOfPeople[indexToEdit].Surname = newSurname;
                                    break;
                                case 3:
                                    int newAge = UserInputNum("Wprowadź nowy wiek osoby: ");
                                    ListOfPeople[indexToEdit].Age = newAge;
                                    break;
                                case 4:
                                    string newSex = UserInputText("Wprowadź nową płeć osoby [m - mężczyzna / k - kobieta]: ");
                                    bool go = true;
                                    while (go)
                                    {
                                        switch (newSex)
                                        {
                                            case "k":
                                                go = false;
                                                break;
                                            case "m":
                                                go = false;
                                                break;
                                            default:
                                                Console.WriteLine("Wprowadzono nieprawidłowe dane");
                                                newSex = UserInputText("Wprowadź nową płeć osoby [m - mężczyzna / k - kobieta]: ");
                                                break;
                                        }
                                    }
                                    ListOfPeople[indexToEdit].Sex = newSex;
                                    break;
                                default:
                                    break;

                            }
                            Console.WriteLine("Dane zostały zmienione");
                            Console.WriteLine("Czy chcesz wyedytować kolejny rekord? [T/n]: ");
                            string editAgain = Console.ReadLine();
                            do
                            {
                                switch (editAgain)
                                {
                                    case "T":
                                        Console.Clear();
                                        break;
                                    case "n":
                                        Console.Clear();
                                        return;
                                    default:
                                        Console.WriteLine("Wybierz ponownie - czy chcesz wyedytować kolejny rekord? [T/n]: ");
                                        editAgain = Console.ReadLine();
                                        break;
                                }
                            } while (editAgain != "T");
                        }
                    }
                }
            }

        }

        private static void Overview()
        {
            Console.Clear();
            Console.WriteLine("== PRZEGLĄD REJESTRU ==");
            if (ListOfPeople.Count <= 0)
            {
                Console.WriteLine("Rejestr jest pusty");
                Console.WriteLine("Wciśnij dowolny przycisk aby powrócić");
                Console.ReadKey();
                Console.Clear();
            }
            else if(ListOfPeople.Count > 10)
            {
                int size = ListOfPeople.Count;
                int counter = 0;
                Console.WriteLine($"Rejestr zawiera {size} wpisów");
                while (true)
                {
                    Console.WriteLine($"{counter + 1} strona rejestru: ");
                    for (int a = counter * 10; a < 10 * (counter + 1) && a < size; a++)
                    {
                        Console.WriteLine(ListOfPeople[a].ToString());
                    }

                    if (10 * (counter + 1) < size)
                    {

                        Console.WriteLine("Czy wyświetlić dalszą część rejestru? [T/n]: ");
                        string decision = Console.ReadLine();
                        do
                        {
                            switch (decision)
                            {
                                case "T":
                                    Console.Clear();
                                    counter++;
                                    break;
                                case "n":
                                    Console.Clear();
                                    return;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                    decision = Console.ReadLine();
                                    break;
                            }

                        } while (decision != "T");
                    } else
                    {
                        Console.WriteLine("Czy wyświetlić rejestr ponownie? [T/n]: ");
                        string decision = Console.ReadLine();
                        do
                        {
                            switch (decision)
                            {
                                case "T":
                                    Console.Clear();
                                    counter = 0;
                                    break;
                                case "n":
                                    Console.Clear();
                                    return;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Wybierz ponownie [T/n]: ");
                                    decision = Console.ReadLine();
                                    break;
                            }

                        } while (decision != "T");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Rejestr osób zawiera {ListOfPeople.Count}");
                foreach (var osoba in ListOfPeople)
                {
                    Console.WriteLine(osoba.ToString());
                }
                Console.WriteLine("Wciśnij dowolny przycisk aby powrócić do menu: ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DeleteData()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("== USUWANIE DANYCH Z REJESTRU ==");
                if (ListOfPeople.Count <= 0)
                {
                    Console.WriteLine("Rejestr jest pusty");
                    Console.WriteLine("Wciśnij dowolny przycisk aby powrócić");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                string imie = UserInputText("Wprowadź imie osoby, którą chcesz usunąć z rejestru: ");
                string nazwisko = UserInputText("Wprowadź nazwisko osoby, którą chcesz usunąć z rejestru: ");
                List<Person> result = LookupByNameAndSurname(ListOfPeople, imie, nazwisko);
                if (result.Count <= 0)
                {
                    Console.WriteLine("W rejestrze nie znaleziono wpisu zawierającego wskazane dane");
                    Console.WriteLine("Czy kontynuować wyszukiwanie? [T/n]: ");
                    string decision = Console.ReadLine();
                    do
                    {
                        switch (decision)
                        {
                            case "T":
                                Console.Clear();
                                break;
                            case "n":
                                Console.Clear();
                                return;
                            default:
                                Console.Clear();
                                Console.WriteLine("Wybierz ponownie [T/n]: ");
                                decision = Console.ReadLine();
                                break;
                        }

                    } while (decision != "T");
                }
                else
                {
                    Console.WriteLine($"Odnaleziono {result.Count} wpisów w rejestrze");
                    foreach (var record in result)
                    {
                        Console.WriteLine($"{ListOfPeople.IndexOf(record)}. {record}");
                    }
                    int indexToRemove = UserInputNum("Podaj numer wpisu do usunięcia: ");

                    while (!ListOfPeople[indexToRemove].IsReady())
                    {
                        indexToRemove = UserInputNum("Wprowadzono błedy numer wpisu - wprowadź numer ponownie");
                        foreach (var record in result)
                        {
                            Console.WriteLine($"{ListOfPeople.IndexOf(record)}. {record}");
                        }
                    }

                    Console.WriteLine(ListOfPeople[indexToRemove].ToString());
                    Console.WriteLine("Czy dane tej osoby mają zostać usunięte z rejestru? [T/n]: ");
                    string decision = Console.ReadLine();
                    do
                    {
                        switch (decision)
                        {
                            case "T":
                                Console.Clear();
                                break;
                            case "n":
                                Console.Clear();
                                return;
                            default:
                                Console.Clear();
                                Console.WriteLine("Wybierz ponownie [T/n]: ");
                                decision = Console.ReadLine();
                                break;
                        }

                    } while (decision != "T");
                    if (VeriFier())
                    {
                        ListOfPeople.RemoveAt(indexToRemove);
                    }
                    Console.WriteLine("Wskazana osoba została usunięta z rejestru");
                    Console.WriteLine("Czy chcesz kontynuować usuwanie osób z rejestru? [T/n]: ");
                    string removeMore = Console.ReadLine();
                    do
                    {
                        switch (removeMore)
                        {
                            case "T":
                                Console.Clear();
                                break;
                            case "n":
                                Console.Clear();
                                return;
                            default:
                                Console.WriteLine("Wybierz ponownie [T/n]: ");
                                removeMore = Console.ReadLine();
                                break;
                        }

                    } while (removeMore != "T");
                }
            }
        }

        
        private static void SerializeToXML()
        {
            Console.Clear();
            Console.WriteLine("== EKSPORT DANYCH Z REJESTRU DO PLIKU XML ==");
            if (ListOfPeople.Count > 0)
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(List<Person>));
                string myPath = Path.Combine(Environment.CurrentDirectory, "register.xml");
                using (FileStream myStream = File.Create(myPath))
                {
                    mySerializer.Serialize(myStream, ListOfPeople);
                }
                Console.WriteLine("Rejestr został wyeksportowany do pliku register.xml");
                Console.WriteLine("Wciśnij dowolny przycisk aby kontynuować: ");
                Console.ReadKey();
                Console.Clear();
            } else
            {
                Console.WriteLine("Rejestr jest pusty");
                Console.WriteLine("Wciśnij dowolny przycisk aby kontynuować: ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DeserializeFromXML()
        {

            object importedRegister = null;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("== IMPORT DANYCH DO REJESTRU Z PLIKU XML ==");
                string userPath = UserInputText("Wprowadź ścieżkę do pliku XML, który ma zostać zaimportowany: ");
                while (!File.Exists(userPath))
                {
                    userPath = UserInputText("Wskazana ścieżka nie jest prawidłowa! Wprowadź ścieżkę do pliku XML, który ma zostać zaimportowany: ");
                }
                XmlSerializer myDeserializer = new XmlSerializer(typeof(List<Person>));
                TextReader fileReader = new StreamReader(userPath);
                importedRegister = myDeserializer.Deserialize(fileReader);

                ListOfPeople.AddRange((List<Person>)importedRegister);
                Console.WriteLine("Rejestr został zaimportowany ze wskazanego pliku");
                Console.WriteLine("Wciśnij dowolny przycisk aby kontynuować: ");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            
        }

        public static void Main(string[] args)
        {
            App();
        }
    }
}
