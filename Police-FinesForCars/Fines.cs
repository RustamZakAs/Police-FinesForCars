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
        public string Type { get; set; }
        [DataMember]
        public float Amount { get; set; }
        [DataMember]
        public Cars Car { get; set; }
    }
}
