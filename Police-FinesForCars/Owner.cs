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
        public Document[] MyDocuments { get; set; }
        [DataMember]
        public Cars[] MyCars { get; set; }
        [DataMember]
        public Fines[] MyFines { get; set; }
        public Owner()
        {
            MyDocuments = new Document[] { };
            MyCars = new Cars[] { };
            MyFines = new Fines[] { };
        }
        
        public override string ToString()
        {
            return $"{MyDocuments[0].Name} {MyDocuments[0].Surname} {MyDocuments[0].Patronime}";
        }
    }
}
