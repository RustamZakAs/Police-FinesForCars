using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    internal class Document : Persons
    {
        public string RegistrationMark { get; set; }

        public Document()
        {
            
        }

        public Document(string registrationMark)
        {

        }

        public Document(Document doc)
        {
            string name = doc.Name;
            string surname = doc.Surname;
            string patronime = doc.Patronime;
            DateTime birtday = doc.Birtday;
            string registrationMark = doc.RegistrationMark;
        }
        public Document(Persons per)
        {
            string name = per.Name;
            string surname = per.Surname;
            string patronime = per.Patronime;
            DateTime birtday = per.Birtday;
        }
    }
}
