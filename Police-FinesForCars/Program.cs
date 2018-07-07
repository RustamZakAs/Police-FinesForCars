using System;
using System.Collections.Generic;
using System.Linq;
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

            do
            {
                Console.Clear();
                Console.WriteLine($"1. {dictionary["newper"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["newcar"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["newdoc"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["newfine"].RetLang(staticLanguage)} ");
                Console.WriteLine($"5. {dictionary["showall"].RetLang(staticLanguage)} ");
                Console.WriteLine($"6. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = Console.ReadKey();


                switch (cki.KeyChar)
                {
                    case '1':
                        Console.WriteLine("Yeni şəxs əlavə et: ");
                        person.AddPerson();

                        owner.MyDocuments.Add(new Document(person));
                        owners.Add(owner);

                        Console.WriteLine(person);

                        if (owners.Count > 0)
                            SaveAll(owners, "people");
                        owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
                        break;
                    case '2':
                        if (owners.Count == 0)
                        {
                            goto case '1';
                        }
                        else
                        {
                            string insert_name = "";
                            string insert_surname = "";
                            string insert_patronime = "";
                            bool x_exit = true;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"1. {dictionary["insertname"].RetLang(staticLanguage)} ");
                                Console.WriteLine($"2. {dictionary["insertsurname"].RetLang(staticLanguage)} ");
                                Console.WriteLine($"3. {dictionary["insertpatronime"].RetLang(staticLanguage)} ");
                                Console.WriteLine($"4. {dictionary["search"].RetLang(staticLanguage)} ");
                                Console.WriteLine($"5. {dictionary["exit"].RetLang(staticLanguage)} ");
                                cki = Console.ReadKey();

                                switch (cki.KeyChar)
                                {
                                    case '1':
                                        Console.WriteLine($"1. {dictionary["insertname"].RetLang(staticLanguage)} ");
                                        insert_name = Console.ReadLine();
                                        break;
                                    case '2':
                                        Console.WriteLine($"2. {dictionary["insertsurname"].RetLang(staticLanguage)} ");
                                        insert_surname = Console.ReadLine();
                                        break;
                                    case '3':
                                        Console.WriteLine($"3. {dictionary["insertpatronime"].RetLang(staticLanguage)} ");
                                        insert_patronime = Console.ReadLine();
                                        break;
                                    case '4':
                                        int i = 0;
                                        for (; i < owners.Count; i++)
                                        {
                                            foreach (var md in owners[i].MyDocuments)
                                            {
                                                if (md.Name == insert_name)
                                                {
                                                    int xxx = md.Name.IndexOf(insert_name);
                                                    //md.Name.IndexOf(insert_name)
                                                    //md.Surname.IndexOf(insert_surname) 
                                                    Console.WriteLine(md);
                                                    car.AddCar();
                                                    Console.WriteLine(car);
                                                    owners[i].MyCars.Add(car);

                                                    if (owners.Count > 0)
                                                        SaveAll(owners, "people");
                                                    owners = (List<Owner>)ReadAll(new List<Owner>(), "people");

                                                    foreach (var item in owners[i].MyCars)
                                                    {
                                                        Console.WriteLine(item);
                                                    }
                                                    Console.ReadKey();
                                                }
                                            }
                                        }
                                        break;
                                    case '5':
                                        x_exit = false;
                                        break;
                                    default:
                                        break;
                                }
                            } while (x_exit);
                        }
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

                        break;
                    case '5':
                        Console.WriteLine("Hamısına baxma: ");
                        owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
                        Console.WriteLine(owners);
                        foreach (var ow in owners)
                        {
                            foreach (var doc in ow.MyDocuments)
                            {
                                Console.WriteLine($"-+{ doc }");
                            }
                            foreach (var car in ow.MyCars)
                            {
                                Console.WriteLine($"------{ car }");
                            }
                            foreach (var fin in ow.MyFines)
                            {
                                Console.WriteLine($"---+++{ fin }");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case '6':
                        if (owners.Count > 0)
                            SaveAll(owners, "people");
                        Environment.Exit(1);
                        break;
                    default:
                        MainMenyu();
                        break;
                }
            
                Console.ReadKey();
            } while (true);
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
