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
        public static Document document = new Document();
        public static Fines fine = new Fines();
        public static RegistrationMark docRegKod = new RegistrationMark();
        public static Cars car = new Cars();

        public static Owner owner = new Owner();
        public static List<Owner> owners = new List<Owner>();

        static void Main(string[] args)
        {
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
                Console.WriteLine($"1. {dictionary["workperinfo"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["workcarinfo"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["workdocinfo"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["workfineinfo"].RetLang(staticLanguage)} ");
                Console.WriteLine($"5. {dictionary["showall"].RetLang(staticLanguage)} ");
                Console.WriteLine($"6. {dictionary["exit"].RetLang(staticLanguage)} ");

                Statistics statistics = new Statistics(ref owners);

                ConsoleKeyInfo cki = Console.ReadKey();
                int tempId = 99999;
                switch (cki.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        WorkWhisPerson();
                        break;
                    case '2':
                        Console.Clear();
                        tempId = SearchOwner();
                        if (tempId == 99999)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            goto case '2';
                        }
                        WorkWhisCar(tempId);
                        break;
                    case '3':
                        Console.WriteLine("Yeni sənəd əlavə et: ");
                        Console.WriteLine("Sənən növünü qeyd edin: ");
                        document.DocType = Console.ReadLine();
                        Console.WriteLine("Sənədin seriyasını qeyd edin: ");
                        docRegKod.Seriya = Console.ReadLine();
                        Console.WriteLine("Sənədin nömrəsini qeyd edin: ");
                        docRegKod.Number = Console.ReadLine();
                        break;
                    case '4':
                        Console.WriteLine("Yeni cərimə əlavə et: ");
                        WorkWhisFine();
                        break;
                    case '5':
                        Console.WriteLine();
                        Console.WriteLine("Hamısına baxma: ");
                        owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
                        //Console.WriteLine(owners);
                        for (int i = 0; i < owners.Count; i++)
                        {
                            Console.Write($"+{ i }+");
                            foreach (var doc in owners[i].MyDocuments)
                            {
                                Console.WriteLine($"-+{ doc }");
                            }
                            foreach (var car in owners[i].MyCars)
                            {
                                Console.WriteLine($"------{ car }");
                            }
                            foreach (var fin in owners[i].MyFines)
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
        static void WorkWhisPerson()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"1. {dictionary["newper"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["delper"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["changeper"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = Console.ReadKey();
                int tempId = 0;
                if (cki.Key == ConsoleKey.Escape) MainMenyu();
                switch (cki.KeyChar)
                {
                    case '1':
                        person.AddPerson();
                        if (Search.SearchWhisInfo(ref owners, person.Name, person.Surname,
                            person.Patronime, person.BirtDay, "", "", "") == 99999)
                        {
                            Console.WriteLine("Yazılan məlumat artıq var");
                            Console.ReadKey();
                            person.AddPerson();
                        }
                        else
                        {
                            owner.Add(person);
                            owners.Add(owner);

                            Console.WriteLine("Məlumat yazıldı!");
                            Console.WriteLine(person);
                            Console.ReadKey();
                        }
                        break;
                    case '2':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            Console.ReadKey();
                            goto case '2';
                        }
                        owners.RemoveAt(tempId);
                        Console.WriteLine("Məlumat silindi!");
                        break;
                    case '3':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            Console.ReadKey();
                            goto case '3';
                        }
                        Console.WriteLine(owners[tempId].MyDocuments);
                        Console.WriteLine("Məlumat dəyişmək olmaz!");
                        break;
                    case '4':
                        MainMenyu();
                        break;
                    default:
                        MainMenyu();
                        break;
                }
                SaveLoad();
            } while (true);
        }

        static void ChangePersonInfo(int owner_index)
        {
            string c_name = "";
            string c_surname = "";
            string c_patronime = "";
            DateTime c_birdth = DateTime.Parse("01.01.1900");
            string c_placeofbirdth = "";
            string c_seria = "";
            string c_number = "";
            string c_doctype = "";

            do
            {
                Console.WriteLine("Change name");
                Console.WriteLine($"{ owners[owner_index].MyDocuments }");
                c_name = Console.ReadLine();
                Console.WriteLine("Change surname");
                c_surname = Console.ReadLine();
                Console.WriteLine("Change patronime");
                c_patronime = Console.ReadLine();
                Console.WriteLine("Change Date of Birdth");
                c_birdth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Change Please of Birdth");
                c_placeofbirdth = Console.ReadLine();
                Console.WriteLine("Change Document seria");
                c_seria = Console.ReadLine();
                Console.WriteLine("Change Document serial number");
                c_number = Console.ReadLine();
                Console.WriteLine("Change Document type");
                c_doctype = Console.ReadLine();
            } while (true);
        }

        static int SearchOwner()
        {
            string insert_name = "";
            string insert_surname = "";
            string insert_patronime = "";
            DateTime insert_dateofbirdth = DateTime.Parse("01.01.1900");
            string insert_reg_ser = "";
            string insert_reg_kod = "";
            string insert_car_serial_number = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Система поиска персоны по введённым данным");
                Console.WriteLine($"1. {dictionary["insertname"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["insertsurname"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["insertpatronime"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["insertdateofbirdth"].RetLang(staticLanguage)} ");
                Console.WriteLine($"5. {dictionary["insertregkod"].RetLang(staticLanguage)} ");
                Console.WriteLine($"6. {dictionary["insertcarsernum"].RetLang(staticLanguage)} ");
                Console.WriteLine($"7. {dictionary["search"].RetLang(staticLanguage)} ");
                Console.WriteLine($"8. {dictionary["exit"].RetLang(staticLanguage)} ");
                ConsoleKeyInfo cki = Console.ReadKey();

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
                        Console.WriteLine($"4. {dictionary["insertdateofbirdth"].RetLang(staticLanguage)} ");
                        insert_patronime = Console.ReadLine();
                        break;
                    case '5':
                        Console.WriteLine($"5. {dictionary["insertregkod"].RetLang(staticLanguage)} ");
                        Console.WriteLine("Seria");
                        insert_reg_ser = Console.ReadLine();
                        Console.WriteLine("Kod");
                        insert_reg_kod = Console.ReadLine();
                        break;
                    case '6':
                        Console.WriteLine($"6. {dictionary["insertcarsernum"].RetLang(staticLanguage)} ");
                        insert_car_serial_number = Console.ReadLine();
                        break;
                    case '7':
                        int xxx = Search.SearchWhisInfo(ref owners, insert_name, insert_surname, insert_patronime, insert_dateofbirdth, insert_reg_ser, insert_reg_kod, insert_car_serial_number);
                        if (xxx == 99999)
                        {
                            Console.WriteLine("Təkrar olan məlumat tapıldı! Məlumat azdır");
                            Console.WriteLine(insert_name);
                            Console.WriteLine(insert_surname);
                            Console.WriteLine(insert_patronime);
                            Console.WriteLine(insert_reg_ser);
                            Console.WriteLine(insert_reg_kod);
                            Console.WriteLine(insert_car_serial_number);
                            Console.ReadKey();
                        }
                        else return xxx;
                        break;
                    case '8':
                        WorkWhisPerson();
                        break;
                }
            } while (true);
        }

        static void WorkWhisCar(int personId = 99999)
        {
            do
            {
                Console.Clear();

                Console.WriteLine($"{owners[personId].MyDocuments[0]}");

                Console.WriteLine($"1. {dictionary["newcar"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["delcar"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["changecar"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape) MainMenyu();
                int tempId = 0;
                switch (cki.KeyChar)
                {
                    case '1':
                        if (owners.Count == 0)
                        {
                            person.AddPerson();
                            owner.Add(person);
                            owners.Add(owner);

                            Console.WriteLine(person);
                        }
                        else
                        {
                            tempId = SearchOwner();
                            if (tempId == 99999 | tempId == 77777)
                            {
                                Console.WriteLine("Axtarıla məlumat tapılmadı!");
                                Console.ReadKey();
                                goto case '1';
                            }
                            car.Add();
                            owners[personId].MyCars.Add(car);
                        }
                        break;
                    case '2':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            Console.ReadKey();
                            goto case '2';
                        }
                        int i = 0;
                        for (; i < owners[tempId].MyCars.Count; i++)
                        {
                            Console.WriteLine($"{i} - {owners[tempId].MyCars[i]}");
                        }
                        Console.WriteLine("Press Car id: ");
                        int tempCarId = int.Parse(Console.ReadLine());
                        owners[tempId].MyCars.RemoveAt(i);
                        Console.WriteLine("Məlumat silindi!");
                        break;
                    case '3':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            Console.ReadKey();
                            goto case '3';
                        }
                        Console.WriteLine(owners[tempId].MyCars);
                        Console.WriteLine("Məlumat dəyişmək olmaz!");
                        break;
                    case '4':
                        MainMenyu();
                        break;
                    default:
                        MainMenyu();
                        break;
                }
                SaveLoad();
            } while (true);
        }

        static void WorkWhisFine()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"1. {dictionary["newfine"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["delfine"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["changefine"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["closefine"].RetLang(staticLanguage)} ");
                Console.WriteLine($"5. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape) MainMenyu();
                int tempId = 0;
                switch (cki.KeyChar)
                {
                    case '1':
                        if (owners.Count == 0)
                        {
                            tempId = SearchOwner();
                            if (tempId == 99999 | tempId == 77777)
                            {
                                Console.WriteLine("Axtarıla məlumat tapılmadı!");
                                Console.ReadKey();
                                goto case '1';
                            }

                            Console.WriteLine(owners[tempId]);

                            fine.Add(tempId);
                            //owner.Add(person);
                            //owners.Add(owner);
                        }
                        else
                        {
                            tempId = SearchOwner();
                            if (tempId == 99999 | tempId == 77777)
                            {
                                Console.WriteLine("Axtarıla məlumat tapılmadı!");
                                Console.ReadKey();
                                goto case '1';
                            }
                            fine.Add();
                            owners[tempId].MyFines.Add(fine);
                        }
                        break;
                    case '2':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            Console.ReadKey();
                            goto case '2';
                        }
                        foreach (var item in owners[tempId].MyFines)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case '3':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            Console.ReadKey();
                            goto case '3';
                        }
                        break;
                    case '4':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            Console.ReadKey();
                            goto case '4';
                        }
                        break;
                    case '5':
                        MainMenyu();
                        break;
                    default:
                        MainMenyu();
                        break;
                }
                SaveLoad();
            } while (true);
        }

        static void SaveLoad()
        {
            if (owners.Count > 0)
                SaveAll(owners, "people");
            owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
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
