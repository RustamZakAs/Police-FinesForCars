using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Police_FinesForCars
{
    [DataContract]
    class Fines
    {
        [DataMember]
        public string ProtocolCode { get; set; }
        [DataMember]
        public DateTime ProtocolDateTime { get; set; }
        [DataMember]
        public string Type { get; set; } //
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public string CarSerialNumber { get; set; }
        [DataMember]
        private bool close;
        public bool Close()
        {
            return close;
        }
        public void Close(bool value = false)
        {
            close = value;
        }

        public void AddFine()
        {
            Console.WriteLine("Please Enter Fine Information");
            Console.WriteLine("Enter protocol code: ");
            ProtocolCode = Console.ReadLine();
            Console.WriteLine("Enter protocol date and time: ");
            ProtocolDateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter protocol type: ");
            Type = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            Street = Console.ReadLine();
            Console.WriteLine("Enter fine amount: ");
            Amount = Single.Parse(Console.ReadLine());
            Console.WriteLine("Enter car serial number: ");
            CarSerialNumber = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"{Program.dictionary["protnum"].RetLang(Program.staticLanguage)} - { ProtocolCode }\n" +
                   $"{Program.dictionary["protdate"].RetLang(Program.staticLanguage)} - { ProtocolDateTime }\n" +
                   $"{Program.dictionary["protadress"].RetLang(Program.staticLanguage)} - { Street }\n" +
                   $"{Program.dictionary["prottype"].RetLang(Program.staticLanguage)} - { Type }\n" +
                   $"{Program.dictionary["protamount"].RetLang(Program.staticLanguage)} - { Amount }\n" +
                   $"{Program.dictionary["protcar"].RetLang(Program.staticLanguage)} - { CarSerialNumber }\n" +
                   $"{Program.dictionary["protpaid"].RetLang(Program.staticLanguage)} - { Close() }\n";
        }
    }
}
