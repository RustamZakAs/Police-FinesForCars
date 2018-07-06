using System;
using System.Collections.Generic;
//using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Police_FinesForCars
{
    [DataContract]
    class Owner
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
        
        public override string ToString()
        {
            return $"{MyDocuments[0].Name} {MyDocuments[0].Surname} {MyDocuments[0].Patronime}";
        }
    }
}
