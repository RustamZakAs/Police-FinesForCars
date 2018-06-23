using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Police_FinesForCars
{
    [DataContract]
    class Person
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Patronime { get; set; }
        [DataMember]
        public DateTime BirtDay { get; set; }
        [DataMember]
        public string PlaceOfBirth{ get; set; }
        public override string ToString()
        {
            return $"{Name} {Surname} {Patronime} {BirtDay} {PlaceOfBirth}";
        }
        public void AddPerson ()
        {
            Console.WriteLine("Yeni şəxs əlavə et: ");
            Console.WriteLine("Adı: ");
            Name = Console.ReadLine();
            Console.WriteLine("Soyadı: ");
            Surname = Console.ReadLine();
            Console.WriteLine("Ata adı: ");
            Patronime = Console.ReadLine();
            Console.WriteLine("Doğum tarixi: ");
            string birt = Console.ReadLine();
            if (DateTime.TryParse(birt, out DateTime bdate))
            {
                BirtDay = bdate;
            }
            else BirtDay = DateTime.Parse("01.01.1900");
            Console.WriteLine("Doğum yeri: ");
            PlaceOfBirth = Console.ReadLine();
        }
    }
    [DataContract]
    class RegistrationMark
    {
        [DataMember]
        public string Seriya { get; set; }
        [DataMember]
        public string Number { get; set; }

        public override string ToString()
        {
            return $"{Seriya}{Number}";
        }
    }
    [DataContract]
    class Document : Person
    {
        [DataMember]
        public string DocType { get; set; }
        [DataMember]
        public RegistrationMark RegistrationKod { get;}

        public Document()
        {
            
        }

        public Document(string registrationMark)
        {

        }

        public Document(Document doc)
        {
            Name = doc.Name;
            Surname = doc.Surname;
            Patronime = doc.Patronime;
            BirtDay = doc.BirtDay;
            RegistrationKod.Seriya = doc.RegistrationKod.Seriya;
            RegistrationKod.Number = doc.RegistrationKod.Number;
        }
        public Document(Person per)
        {
            Name = per.Name;
            Surname = per.Surname;
            Patronime = per.Patronime;
            BirtDay = per.BirtDay;
        }
        public void Add(Person per)
        {
            Name = per.Name;
            Surname = per.Surname;
            Patronime = per.Patronime;
            BirtDay = per.BirtDay;
        }
    }
}
