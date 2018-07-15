using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Police_FinesForCars
{
    [DataContract]
    public class RegistrationMark
    {
        [DataMember]
        public string Seriya { get; set; }
        [DataMember]
        public string Number { get; set; }

        public override string ToString()
        {
            return $"{Seriya} {Number}";
        }

        public void Add()
        {
            Console.WriteLine("Please Insert Document Seria and Number");
            Console.WriteLine("Seriya");
            Seriya = Console.ReadLine();
            Console.WriteLine("Number");
            Number = Console.ReadLine();
        }
    }

    [DataContract]
    public class Document
    {
        [DataMember]
        public string DocType { get; set; }
        [DataMember]
        public List<string> CarSerialNumber { get; set; }
        [DataMember]
        public RegistrationMark RegistrationKod { get; set; }

        public Document()
        {
            
        }

        public Document(string registrationMark)
        {

        }

        public Document(Document doc)
        {
            //Name = doc.Name;
            //Surname = doc.Surname;
            //Patronime = doc.Patronime;
            //BirtDay = doc.BirtDay;
            //PlaceOfBirth = doc.PlaceOfBirth;
            RegistrationKod.Seriya = doc.RegistrationKod.Seriya;
            RegistrationKod.Number = doc.RegistrationKod.Number;
        }

        public void Add()
        {
            Console.WriteLine("Please Insert Document Information");
            Console.WriteLine("Document type");
            DocType = Console.ReadLine();
            Console.WriteLine("Number");
            RegistrationMark tempRM = new RegistrationMark();
            tempRM.Add();
            RegistrationKod = tempRM;
            bool xreplace = true;
            do
            {
                Console.WriteLine("Please Insert Car Serial Number");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Exit");
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape) break;
                switch (cki.KeyChar)
                {
                    case '1':
                        CarSerialNumber.Add(Console.ReadLine());
                        break;
                    case '2':
                        xreplace = false;
                        break;
                    default:
                        break;
                }
            } while (xreplace);
            RegistrationKod.Add();
        }

        public void AddSerialNumber()
        {
            string line = null;
            string pattern = @"^..[0-9]-..[A-Z]-...[0-9]$";
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);

            Console.WriteLine("Введите строку на проверку корректности:");
            line = Console.ReadLine();

            MatchCollection mc = reg.Matches(line);

            Console.ReadKey();
        }
        

        public override string ToString()
        {
            return $"{DocType} {RegistrationKod}";
        }
    }
}
