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
                switch (cki.KeyChar)
                {
                    case '1':
                        person.AddPerson();
                        owner.MyDocuments.Add(new Document(person));
                        owners.Add(owner);

                        Console.WriteLine(person);

                        SaveLoad();
                        break;
                    case '2':
                        Console.WriteLine(SearchOwner());
                        owners.RemoveAt(SearchOwner());
                        SaveLoad();
                        break;
                    case '3':
                        Console.WriteLine(SearchOwner());
                        break;
                    case '4':
                        MainMenyu();
                        break;
                    default:
                        break;
                }
            } while (true);
        }

        static void ChangePersonInfo (int owner_index)
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

        static int SearchOwner ()
        {
            string insert_name = "";
            string insert_surname = "";
            string insert_patronime = "";
            string insert_reg_ser = "";
            string insert_reg_kod = "";
            string insert_car_serial_number = "";

            do
            {
                Console.Clear();
                Console.WriteLine($"1. {dictionary["insertname"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["insertsurname"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["insertpatronime"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["insertregkod"].RetLang(staticLanguage)} ");
                Console.WriteLine($"5. {dictionary["insertcarsernum"].RetLang(staticLanguage)} ");
                Console.WriteLine($"6. {dictionary["search"].RetLang(staticLanguage)} ");
                Console.WriteLine($"7. {dictionary["exit"].RetLang(staticLanguage)} ");
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
                        Console.WriteLine($"4. {dictionary["insertregkod"].RetLang(staticLanguage)} ");
                        Console.WriteLine("Seria");
                        insert_reg_ser = Console.ReadLine();
                        Console.WriteLine("Kod");
                        insert_reg_kod = Console.ReadLine();
                        break;
                    case '5':
                        Console.WriteLine($"4. {dictionary["insertcarsernum"].RetLang(staticLanguage)} ");
                        insert_car_serial_number = Console.ReadLine();
                        break;
                    case '6':
                        int xxx = SearchWhisInfo(insert_name, insert_surname, insert_patronime, insert_reg_ser, insert_reg_kod, insert_car_serial_number);
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
                    case '7':
                        WorkWhisPerson();
                        break;
                }
            } while (true);
        }

        static int SearchWhisInfo(string insert_name = "", 
            string insert_surname = "", 
            string insert_patronime = "", 
            string insert_reg_ser = "", 
            string insert_reg_kod = "", 
            string insert_car_serial_number = "")
        {
            List<int> xindex = new List<int>();

            for (int i = 0; i < owners.Count; i++)
            {
                foreach (var s in owners[i].MyDocuments)
                {
                    if (insert_name.Length > 0)
                    {
                        if (s.Name.Equals(insert_name))
                        {
                            xindex.Add(i);
                        }
                    }
                    if (insert_surname.Length > 0)
                    {
                        if (s.Surname.Equals(insert_surname))
                        {
                            xindex.Add(i);
                        }
                    }
                    if (insert_patronime.Length > 0)
                    {
                        if (s.Patronime.Equals(insert_patronime))
                        {
                            xindex.Add(i);
                        }
                    }
                    if (insert_reg_ser.Length > 0)
                    {
                        if (s.RegistrationKod.Seriya.Equals(insert_reg_ser))
                        {
                            xindex.Add(i);
                        }
                    }
                    if (insert_reg_kod.Length > 0)
                    {
                        if (s.RegistrationKod.Number.Equals(insert_reg_kod))
                        {
                            xindex.Add(i);
                        }
                    }
                    if (insert_car_serial_number.Length > 0)
                    {
                        foreach (var item in s.CarSerialNumber)
                        {
                            if (item.Equals(insert_car_serial_number))
                            {
                                xindex.Add(i);
                            }
                        }
                    }
                }
            }
            Dictionary<int,int> xsxs = new Dictionary<int, int>();
            int xcount = 0;
            foreach (var xi in xindex)
            {
                for (int i = 0; i < xsxs.Count; i++)
                {
                    xcount++;
                }
                if (xcount == 0)
                {
                    xsxs.Add(xi,0);
                    xcount = 0;
                }
            }
            for (int j = 0; j < xindex.Count; j++)
            {
                xsxs[xindex[j]]++;
            }
            int maxCount = 0;
            int indexMaxCount = 0;
            for (int i = 0; i < xsxs.Count; i++)
            {
                if (xsxs[i] > maxCount)
                {
                    indexMaxCount = xsxs[i];
                    maxCount = 0;
                }
            }
            int replayIndex = 0;
            for (int i = 0; i < xsxs.Count; i++)
            {
                if (indexMaxCount == xsxs[i])
                {
                    replayIndex++;
                }
            }
            if (replayIndex > 1) return 99999;
            //for (int i = 0; i < xsxs.Count; i++)
            //{
            //    for (int j = 0; j < xindex.Count; j++)
            //    {
            //        if (xsxs[i] == xindex[j]) xcount++;
            //    }
            //    if (xcount > maxCount)
            //    {
            //        maxCount = xcount;
            //        indexMaxCount = i;
            //    }
            //    xcount = 0;
            //}

            //int[] rezult = new int[1] { indexMaxCount };

            //int[] rezult = new int[xindex.Count == 0 ? 1 : xindex.Count];
            //for (int i = 0; i < xindex.Count; i++)
            //{
            //    rezult[i] = xindex[i];
            //}
            //if (xindex.Count == 0) rezult[0] = 99999;
            return indexMaxCount;
        }

        static void WorkWhisCar()
        {
            do
            {
                Console.Clear();
                Console.WriteLine($"1. {dictionary["newcar"].RetLang(staticLanguage)} ");
                Console.WriteLine($"2. {dictionary["delcar"].RetLang(staticLanguage)} ");
                Console.WriteLine($"3. {dictionary["changecar"].RetLang(staticLanguage)} ");
                Console.WriteLine($"4. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.KeyChar)
                {
                    case '1':
                        if (owners.Count == 0)
                        {
                            person.AddPerson();
                            owner.MyDocuments.Add(new Document(person));
                            owners.Add(owner);

                            Console.WriteLine(person);

                            SaveLoad();
                        }
                        else
                        {
                            int xxx = SearchOwner();
                            Console.WriteLine(xxx);
                            car.AddCar();
                            owners[xxx].MyCars.Add(car);
                        }
                        break;
                    case '2':
                        Console.WriteLine(SearchOwner());
                        break;
                    case '3':
                        Console.WriteLine(SearchOwner());
                        break;
                    case '4':
                        MainMenyu();
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        static void SaveLoad()
        {
            if (owners.Count > 0)
                SaveAll(owners, "people");
            owners = (List<Owner>)ReadAll(new List<Owner>(), "people");
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
                //Console.WriteLine($"2. {dictionary["newcar"].RetLang(staticLanguage)} ");
                //Console.WriteLine($"3. {dictionary["newdoc"].RetLang(staticLanguage)} ");
                //Console.WriteLine($"4. {dictionary["newfine"].RetLang(staticLanguage)} ");
                Console.WriteLine($"5. {dictionary["showall"].RetLang(staticLanguage)} ");
                Console.WriteLine($"6. {dictionary["exit"].RetLang(staticLanguage)} ");

                ConsoleKeyInfo cki = Console.ReadKey();

                switch (cki.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        WorkWhisPerson();
                        break;
                    case '2':
                        WorkWhisCar();
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
