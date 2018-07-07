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
        public string ProtocolNumber { get; set; }
        [DataMember]
        public DateTime ProtocolDateTime { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string Type { get; set; } //
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public Cars Car { get; set; }
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

        public override string ToString()
        {
            return $"{Program.dictionary["protnum"].RetLang(Program.staticLanguage)} - { ProtocolNumber }\n" +
                   $"{Program.dictionary["protdate"].RetLang(Program.staticLanguage)} - { ProtocolDateTime }\n" +
                   $"{Program.dictionary["protadress"].RetLang(Program.staticLanguage)} - { Street }\n" +
                   $"{Program.dictionary["prottype"].RetLang(Program.staticLanguage)} - { Type }\n" +
                   $"{Program.dictionary["protamount"].RetLang(Program.staticLanguage)} - { Amount }\n" +
                   $"{Program.dictionary["protcar"].RetLang(Program.staticLanguage)} - { Car }\n" +
                   $"{Program.dictionary["protpaid"].RetLang(Program.staticLanguage)} - { Close() }\n";
        }
    }
}
