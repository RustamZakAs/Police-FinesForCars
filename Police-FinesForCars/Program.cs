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
        //public static List<Person> people = new List<Person>();
        //public static List<RegistrationMark> regKods = new List<RegistrationMark>();
        //public static List<Document> docs = new List<Document>();


        static void Main(string[] args)
        {
            MainMenyu();
        }
        static void MainMenyu ()
        {
            var person = new Person();
            Console.WriteLine("Yeni şəxs əlavə et: ");
            Console.WriteLine("Adı: ");
            person.Name = Console.ReadLine();
            Console.WriteLine("Soyadı: ");
            person.Surname = Console.ReadLine();
            Console.WriteLine("Ata adı: ");
            person.Patronime = Console.ReadLine();
            Console.WriteLine("Doğum tarixi: ");
            string birt = Console.ReadLine();
            person.BirtDay = DateTime.Parse(birt);

            var document = new Document();
            Console.WriteLine("Sənən növünü qeyd edin: ");
            document.DocType = Console.ReadLine();


            Console.ReadKey();
            //people.Add(person);
            SaveAll(person, "people");

            Person per = (Person)ReadAll(new Person(), "people");
            Console.WriteLine(per);
            Console.ReadKey();
        }
        static public void SaveAll(object obj, string fileName)
        {
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
