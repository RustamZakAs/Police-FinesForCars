using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Police_FinesForCars
{
    [DataContract]
    class Owner
    {
        public Owner()
        {
        }

        [DataMember]
        public Document[] MyDocuments { get; set; }
        [DataMember]
        public Cars[] MyCars { get; set; }
        [DataMember]
        public Fines[] MyFines { get; set; }
    }
}
