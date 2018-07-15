using System;
using System.Collections.Generic;
//using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Police_FinesForCars
{
    [DataContract]
    public class Owner : Person
    {
        [DataMember]
        public List<Document> MyDocuments = new List<Document> { };
        [DataMember]
        public List<Cars> MyCars = new List<Cars> { };
        [DataMember]
        public List<Fines> MyFines = new List<Fines> { };

        public Owner()
        {

        }

        public Owner(Person per)
        {
            Add(per);
        }

        public void Add(Person per)
        {
            Name = per.Name;
            Surname = per.Surname;
            Patronime = per.Patronime;
            BirtDay = per.BirtDay;
            PlaceOfBirth = per.PlaceOfBirth;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Patronime}";
        }
    }
}
