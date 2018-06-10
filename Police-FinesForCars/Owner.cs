using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Police_FinesForCars
{
    class Owner
    {
        public Document MyDocuments { get; set; }
        public Cars[] MyCars { get; set; }
        public Fines[] MyFines { get; set; }
    }
}
