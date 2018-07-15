using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Drawing;
using Colorful;

namespace Police_FinesForCars
{
    class Program
    {
        public static int staticLanguage = (int)Lang.RU;

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
            System.Console.Title = "Cərimələr";
            System.Console.OutputEncoding = Encoding.Unicode;
            System.Console.InputEncoding  = Encoding.Unicode;

            ConsoleFont2.SetConsoleFont("Consolas");

            do
            {
                System.Console.Clear();
                //Console.WriteLine($"1. {dictionary["workperinfo"].RetLang(staticLanguage)} ");
                //Console.WriteLine($"2. {dictionary["workcarinfo"].RetLang(staticLanguage)} ");
                //Console.WriteLine($"3. {dictionary["workdocinfo"].RetLang(staticLanguage)} ");
                //Console.WriteLine($"4. {dictionary["workfineinfo"].RetLang(staticLanguage)} ");
                //Console.WriteLine($"5. {dictionary["showall"].RetLang(staticLanguage)} ");
                //Console.WriteLine($"6. {dictionary["exit"].RetLang(staticLanguage)} ");

                ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
                ColorAlternator alternator = alternatorFactory.GetAlternator(2, Color.Plum, Color.PaleVioletRed);

                for (int i = 0; i < 15; i++)
                {
                    Colorful.Console.WriteLineAlternating("cats", alternator);
                }


                string[] storyFragments = new string[] { $"1. {dictionary["workperinfo"].RetLang(staticLanguage)} ",
                                                         $"2. {dictionary["workcarinfo"].RetLang(staticLanguage)} ",
                                                         $"3. {dictionary["workdocinfo"].RetLang(staticLanguage)} ",
                                                         $"4. {dictionary["workfineinfo"].RetLang(staticLanguage)} ",
                                                         $"5. {dictionary["showall"].RetLang(staticLanguage)} ",
                                                         $"6. {dictionary["exit"].RetLang(staticLanguage)} "};
                int r = 225;
                int g = 255;
                int b = 250;
                for (int i = 0; i < storyFragments.Length; i++)
                {
                    System.Console.WriteLine(storyFragments[i], Color.FromArgb(r, g, b));

                    r -= 18;
                    b -= 9;
                }


                Statistics statistics = new Statistics(ref owners);

                ConsoleKeyInfo cki = System.Console.ReadKey();
                int tempId = 99999;
                switch (cki.KeyChar)
                {
                    case '1':
                        System.Console.Clear();
                        WorkWhisPerson();
                        break;
                    case '2':
                        System.Console.Clear();
                        tempId = SearchOwner();
                        if (tempId == 99999)
                        {
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            goto case '2';
                        }
                        WorkWhisCar(tempId);
                        break;
                    case '3':
                        System.Console.WriteLine("Yeni sənəd əlavə et: ");
                        System.Console.WriteLine("Sənən növünü qeyd edin: ");
                        document.DocType = System.Console.ReadLine();
                        System.Console.WriteLine("Sənədin seriyasını qeyd edin: ");
                        docRegKod.Seriya = System.Console.ReadLine();
                        System.Console.WriteLine("Sənədin nömrəsini qeyd edin: ");
                        docRegKod.Number = System.Console.ReadLine();
                        break;
                    case '4':
                        System.Console.WriteLine("Yeni cərimə əlavə et: ");
                        WorkWhisFine();
                        break;
                    case '5':
                        System.Console.WriteLine();
                        System.Console.WriteLine("Hamısına baxma: ");
                        owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
                        //System.Console.WriteLine(owners);
                        for (int i = 0; i < owners.Count; i++)
                        {
                            System.Console.Write($"+{ i }+");
                            foreach (var doc in owners[i].MyDocuments)
                            {
                                System.Console.WriteLine($"-+{ doc }");
                            }
                            foreach (var car in owners[i].MyCars)
                            {
                                System.Console.WriteLine($"------{ car }");
                            }
                            foreach (var fin in owners[i].MyFines)
                            {
                                System.Console.WriteLine($"---+++{ fin }");
                            }
                        }
                        System.Console.ReadKey();
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
            
                System.Console.ReadKey();
            } while (true);
        }
        static void WorkWhisPerson()
        {
            do
            {
                System.Console.Clear();
                System.Console.WriteLine($"1. {dictionary["newper"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"2. {dictionary["delper"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"3. {dictionary["changeper"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"4. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = System.Console.ReadKey();
                int tempId = 0;
                if (cki.Key == ConsoleKey.Escape) MainMenyu();
                switch (cki.KeyChar)
                {
                    case '1':
                        person.AddPerson();
                        if (Search.SearchWhisInfo(ref owners, person.Name, person.Surname,
                            person.Patronime, person.BirtDay, "", "", "") == 99999)
                        {
                            System.Console.WriteLine("Yazılan məlumat artıq var");
                            System.Console.ReadKey();
                            person.AddPerson();
                        }
                        else
                        {
                            owner.Add(person);
                            owners.Add(owner);

                            System.Console.WriteLine("Məlumat yazıldı!");
                            System.Console.WriteLine(person);
                            System.Console.ReadKey();
                        }
                        break;
                    case '2':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            System.Console.ReadKey();
                            goto case '2';
                        }
                        owners.RemoveAt(tempId);
                        System.Console.WriteLine("Məlumat silindi!");
                        break;
                    case '3':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            System.Console.ReadKey();
                            goto case '3';
                        }
                        System.Console.WriteLine(owners[tempId].MyDocuments);
                        System.Console.WriteLine("Məlumat dəyişmək olmaz!");
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
                System.Console.WriteLine("Change name");
                System.Console.WriteLine($"{ owners[owner_index].MyDocuments }");
                c_name = System.Console.ReadLine();
                System.Console.WriteLine("Change surname");
                c_surname = System.Console.ReadLine();
                System.Console.WriteLine("Change patronime");
                c_patronime = System.Console.ReadLine();
                System.Console.WriteLine("Change Date of Birdth");
                c_birdth = DateTime.Parse(System.Console.ReadLine());
                System.Console.WriteLine("Change Please of Birdth");
                c_placeofbirdth = System.Console.ReadLine();
                System.Console.WriteLine("Change Document seria");
                c_seria = System.Console.ReadLine();
                System.Console.WriteLine("Change Document serial number");
                c_number = System.Console.ReadLine();
                System.Console.WriteLine("Change Document type");
                c_doctype = System.Console.ReadLine();
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
                System.Console.Clear();
                System.Console.WriteLine("Система поиска персоны по введённым данным");
                System.Console.WriteLine($"1. {dictionary["insertname"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"2. {dictionary["insertsurname"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"3. {dictionary["insertpatronime"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"4. {dictionary["insertdateofbirdth"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"5. {dictionary["insertregkod"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"6. {dictionary["insertcarsernum"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"7. {dictionary["search"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"8. {dictionary["exit"].RetLang(staticLanguage)} ");
                ConsoleKeyInfo cki = System.Console.ReadKey();

                switch (cki.KeyChar)
                {
                    case '1':
                        System.Console.WriteLine($"1. {dictionary["insertname"].RetLang(staticLanguage)} ");
                        insert_name = System.Console.ReadLine();
                        break;
                    case '2':
                        System.Console.WriteLine($"2. {dictionary["insertsurname"].RetLang(staticLanguage)} ");
                        insert_surname = System.Console.ReadLine();
                        break;
                    case '3':
                        System.Console.WriteLine($"3. {dictionary["insertpatronime"].RetLang(staticLanguage)} ");
                        insert_patronime = System.Console.ReadLine();
                        break;
                    case '4':
                        System.Console.WriteLine($"4. {dictionary["insertdateofbirdth"].RetLang(staticLanguage)} ");
                        insert_patronime = System.Console.ReadLine();
                        break;
                    case '5':
                        System.Console.WriteLine($"5. {dictionary["insertregkod"].RetLang(staticLanguage)} ");
                        System.Console.WriteLine("Seria");
                        insert_reg_ser = System.Console.ReadLine();
                        System.Console.WriteLine("Kod");
                        insert_reg_kod = System.Console.ReadLine();
                        break;
                    case '6':
                        System.Console.WriteLine($"6. {dictionary["insertcarsernum"].RetLang(staticLanguage)} ");
                        insert_car_serial_number = System.Console.ReadLine();
                        break;
                    case '7':
                        int xxx = Search.SearchWhisInfo(ref owners, insert_name, insert_surname, insert_patronime, insert_dateofbirdth, insert_reg_ser, insert_reg_kod, insert_car_serial_number);
                        if (xxx == 99999)
                        {
                            System.Console.WriteLine("Təkrar olan məlumat tapıldı! Məlumat azdır");
                            System.Console.WriteLine(insert_name);
                            System.Console.WriteLine(insert_surname);
                            System.Console.WriteLine(insert_patronime);
                            System.Console.WriteLine(insert_reg_ser);
                            System.Console.WriteLine(insert_reg_kod);
                            System.Console.WriteLine(insert_car_serial_number);
                            System.Console.ReadKey();
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
                System.Console.Clear();

                System.Console.WriteLine($"{owners[personId].MyDocuments[0]}");

                System.Console.WriteLine($"1. {dictionary["newcar"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"2. {dictionary["delcar"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"3. {dictionary["changecar"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"4. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = System.Console.ReadKey();
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

                            System.Console.WriteLine(person);
                        }
                        else
                        {
                            tempId = SearchOwner();
                            if (tempId == 99999 | tempId == 77777)
                            {
                                System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                                System.Console.ReadKey();
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
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            System.Console.ReadKey();
                            goto case '2';
                        }
                        int i = 0;
                        for (; i < owners[tempId].MyCars.Count; i++)
                        {
                            System.Console.WriteLine($"{i} - {owners[tempId].MyCars[i]}");
                        }
                        System.Console.WriteLine("Press Car id: ");
                        int tempCarId = int.Parse(System.Console.ReadLine());
                        owners[tempId].MyCars.RemoveAt(i);
                        System.Console.WriteLine("Məlumat silindi!");
                        break;
                    case '3':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            System.Console.ReadKey();
                            goto case '3';
                        }
                        System.Console.WriteLine(owners[tempId].MyCars);
                        System.Console.WriteLine("Məlumat dəyişmək olmaz!");
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
                System.Console.Clear();
                System.Console.WriteLine($"1. {dictionary["newfine"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"2. {dictionary["delfine"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"3. {dictionary["changefine"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"4. {dictionary["closefine"].RetLang(staticLanguage)} ");
                System.Console.WriteLine($"5. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = System.Console.ReadKey();
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
                                System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                                System.Console.ReadKey();
                                goto case '1';
                            }

                            System.Console.WriteLine(owners[tempId]);

                            fine.Add(tempId);
                            //owner.Add(person);
                            //owners.Add(owner);
                        }
                        else
                        {
                            tempId = SearchOwner();
                            if (tempId == 99999 | tempId == 77777)
                            {
                                System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                                System.Console.ReadKey();
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
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            System.Console.ReadKey();
                            goto case '2';
                        }
                        foreach (var item in owners[tempId].MyFines)
                        {
                            System.Console.WriteLine(item);
                        }
                        break;
                    case '3':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            System.Console.ReadKey();
                            goto case '3';
                        }
                        break;
                    case '4':
                        tempId = SearchOwner();
                        if (tempId == 99999 | tempId == 77777)
                        {
                            System.Console.WriteLine("Axtarıla məlumat tapılmadı!");
                            System.Console.ReadKey();
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
                System.Console.WriteLine(ew);
                throw;
            }
        }
    }
}
