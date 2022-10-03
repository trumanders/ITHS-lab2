using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class Microwave : Appliance
    {

        const string TYPE = "Mikrovågsugn";
        public int CapacityLiters { get; set; }
        public bool hasRotatingPlate { get; set; }

        public Microwave(string brand, bool isFunctioning) : base(brand, isFunctioning)
        {
            this.Type = TYPE;
        }        
    }
}
