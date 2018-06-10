using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    class Fines
    {
        public string ProtocolNumber { get; set; }
        public DateTime ProtocolDateTime { get; set; }
        public string Street { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }
        public Cars Car { get; set; }
    }
}
