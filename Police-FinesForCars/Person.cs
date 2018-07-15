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
    public class Person
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
        public string PlaceOfBirth { get; set; }
        
        public void AddPerson()
        {
            Console.WriteLine("Yeni şəxs əlavə et: ");
            Console.WriteLine("Adı: ");
            Name = Console.ReadLine();
            if (Name.Length == 0) Name = "Rustam";
            Console.WriteLine("Soyadı: ");
            Surname = Console.ReadLine();
            if (Surname.Length == 0) Surname = "Zak";
            Console.WriteLine("Ata adı: ");
            Patronime = Console.ReadLine();
            if (Patronime.Length == 0) Patronime = "As";
            Console.WriteLine("Doğum tarixi: ");
            string birt = Console.ReadLine();
            if (DateTime.TryParse(birt, out DateTime bdate))
            {
                BirtDay = bdate;
            }
            else BirtDay = DateTime.Parse("01.01.1900");
            Console.WriteLine("Doğum yeri: ");
            PlaceOfBirth = Console.ReadLine();
            if (PlaceOfBirth.Length == 0) PlaceOfBirth = "Zaqatala şəh. C.C. 4/5";
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Patronime} {BirtDay} {PlaceOfBirth}";
        }
    }
}
