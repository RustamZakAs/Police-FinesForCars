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
        public static Document document = new Document();
        public static Fines fines = new Fines();
        public static RegistrationMark docRegKod = new RegistrationMark();
        public static Cars car = new Cars();

        public static List<Owner> owners = new List<Owner>();

        //static int a = 6;

        static void Main(string[] args)
        {
            //int a = 5;
            //Console.WriteLine($"{Program.a} and {a}");

            Lanl.CreateDictionary(ref dictionary);
            Person per = (Person)ReadAll(new Person(), "people");
            
            MainMenyu();
        }
        static void MainMenyu ()
        {
            Console.WriteLine($"1. {dictionary["newper"].RetLang(staticLanguage)} ");
            Console.WriteLine($"2. {dictionary["newcar"].RetLang(staticLanguage)} ");
            Console.WriteLine($"3. {dictionary["newdoc"].RetLang(staticLanguage)} ");
            Console.WriteLine($"4. {dictionary["newfine"].RetLang(staticLanguage)} ");
            Console.WriteLine($"5. {dictionary["showall"].RetLang(staticLanguage)} ");

            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.KeyChar == '1')
            {
                person.AddPerson();
                document.Add(person);
            }
            else if (cki.KeyChar == '2')
            {
                Console.WriteLine("Yeni maşın əlavə et: ");
                car.AddCar();
            }
            else if (cki.KeyChar == '3')
            {
                Console.WriteLine("Yeni sənəd əlavə et: ");
                Console.WriteLine("Sənən növünü qeyd edin: ");
                document.DocType = Console.ReadLine();
                Console.WriteLine("Sənədin seriyasını qeyd edin: ");
                docRegKod.Seriya = Console.ReadLine();
                Console.WriteLine("Sənədin nömrəsini qeyd edin: ");
                docRegKod.Number = Console.ReadLine();
            }
            else if (cki.KeyChar == '4')
            {
                Console.WriteLine("Yeni cərimə əlavə et: ");
            }
            else if (cki.KeyChar == '5')
            {
                Console.WriteLine("Hamısına baxma: ");
                Person per = (Person)ReadAll(new Person(), "people");
                Console.WriteLine(per);
                Console.ReadKey();
            }
            else MainMenyu();

            Owner owner = new Owner();

            Document xdocument = new Document(person);

            owners.Add(owner);

            Console.ReadKey();
            //people.Add(person);
            SaveAll(person, "people");
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

            using (FileStream fs = new FileStream($"{fileName}.json", FileMode.OpenOrCreate))
            {
                newpeople = jsonFormatter.ReadObject(fs);
            }
            return newpeople;
        }
    }
}
