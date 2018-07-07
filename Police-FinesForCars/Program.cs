using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Police_FinesForCars
{
    class Program
    {
        public static int staticLanguage = (int)Lang.RU;
        //public static List<Person> people = new List<Person>();
        //public static List<RegistrationMark> regKods = new List<RegistrationMark>();
        //public static List<Document> docs = new List<Document>();

        public static Dictionary<string, RZLanguage> dictionary = new Dictionary<string, RZLanguage>();
        public static RZLanguage Lanl = new RZLanguage();

        public static Person person = new Person();
        //public static Document document = new Document();
        public static Fines fines = new Fines();
        public static RegistrationMark docRegKod = new RegistrationMark();
        public static Cars car = new Cars();

        public static Owner owner = new Owner();
        public static List<Owner> owners = new List<Owner>();

        //static int a = 6;

        static void Main(string[] args)
        {
            //int a = 5;
            //Console.WriteLine($"{Program.a} and {a}");

            Lanl.CreateDictionary(ref dictionary);
            owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
            
            MainMenyu();
        }
        static void MainMenyu ()
        {
            Console.Title = "Cərimələr";
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding  = Encoding.Unicode;

            Console.WriteLine($"1. {dictionary["newper"].RetLang(staticLanguage)} ");
            Console.WriteLine($"2. {dictionary["newcar"].RetLang(staticLanguage)} ");
            Console.WriteLine($"3. {dictionary["newdoc"].RetLang(staticLanguage)} ");
            Console.WriteLine($"4. {dictionary["newfine"].RetLang(staticLanguage)} ");
            Console.WriteLine($"5. {dictionary["showall"].RetLang(staticLanguage)} ");

            ConsoleKeyInfo cki = Console.ReadKey();

            switch (cki.KeyChar)
            {
                case '1':
                    Console.WriteLine("Yeni şəxs əlavə et: ");
                    person.AddPerson();

                    //Document document = new Document(person);// document.Add(person);

                    //owner.MyDocuments.Add(new Document { Name = person.Name,
                    //                                     Surname = person.Surname,
                    //                                     Patronime = person.Patronime,
                    //                                     PlaceOfBirth = person.PlaceOfBirth});
                    owner.MyDocuments.Add(new Document(person));
                    owners.Add(owner);

                    Console.WriteLine(person);

                    if (owners.Count > 0)
                        SaveAll(owners, "people");
                    owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
                    //owner.MyDocuments[owner.MyDocuments.Length] = xdocument;
                    break;
                case '2':
                    if (owners.Count == 0)
                    {
                        goto case '1';
                    }
                    else
                    {
                        string insert_name;
                        string insert_surname;
                        string insert_patronime;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"1. {dictionary["insertname"].RetLang(staticLanguage)} ");
                            insert_name = Console.ReadLine();
                            Console.WriteLine($"2. {dictionary["insertsurname"].RetLang(staticLanguage)} ");
                            insert_surname = Console.ReadLine();
                            Console.WriteLine($"3. {dictionary["insertpatronime"].RetLang(staticLanguage)} ");
                            insert_patronime = Console.ReadLine();
                            cki = Console.ReadKey();
                        } while (cki.KeyChar != '1' | cki.KeyChar != '2' | cki.KeyChar != '3');

                        switch (cki.KeyChar)
                        {
                            case '1':
                                break;
                            case '2':
                                break;
                            default:
                                break;
                        }
                    }

                    Console.WriteLine("Yeni maşın əlavə et: ");
                    car.AddCar();
                    break;
                case '3':
                    Console.WriteLine("Yeni sənəd əlavə et: ");
                    Console.WriteLine("Sənən növünü qeyd edin: ");
                    //document.DocType = Console.ReadLine();
                    Console.WriteLine("Sənədin seriyasını qeyd edin: ");
                    docRegKod.Seriya = Console.ReadLine();
                    Console.WriteLine("Sənədin nömrəsini qeyd edin: ");
                    docRegKod.Number = Console.ReadLine();
                    break;
                case '4':
                    Console.WriteLine("Yeni cərimə əlavə et: ");

                    //owner.MyFines[owner.MyDocuments.Length] = new Fines();
                    break;
                case '5':
                    Console.WriteLine("Hamısına baxma: ");
                    owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
                    Console.WriteLine(owners);
                    foreach (var ow in owners)
                    {
                        foreach (var car in ow.MyCars)
                        {
                            Console.WriteLine(car);
                        }
                    }
                    foreach (var ow in owners)
                    {
                        foreach (var doc in ow.MyDocuments)
                        {
                            Console.WriteLine(doc);
                        }
                    }
                    foreach (var ow in owners)
                    {
                        foreach (var fin in ow.MyFines)
                        {
                            Console.WriteLine(fin);
                        }
                    }
                    Console.ReadKey();
                    break;
                default:
                    MainMenyu();
                    break;
            }
            
            //Console.WriteLine(owner.MyDocuments.Length);
            
            //owner.MyDocuments = new Document[] { };
            
            //owners.Add(owner);

            Console.ReadKey();
            //people.Add(person);
            
        }
        static public void SaveAll(object obj, string fileName)
        {
            if (File.Exists($"{fileName}.json"))
            {
                File.Delete($"{fileName}.json");
            }
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(obj.GetType());

            using (FileStream fs = new FileStream($"{fileName}.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, obj);
            }
        }
        static public object ReadAll(object objectType, string fileName)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(objectType.GetType());
            object newpeople;
            try
            {
                using (FileStream fs = new FileStream($"{fileName}.json", FileMode.OpenOrCreate))
                {
                    if (fs.Length > 0)
                        newpeople = jsonFormatter.ReadObject(fs);
                    else return new List<Owner>(); //--error if "new object()"
                }
                return newpeople;
            }
            catch (Exception ew)
            {
                Console.WriteLine(ew);
                throw;
            }
        }
    }
}
