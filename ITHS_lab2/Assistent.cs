using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class Assistent : Appliance
    {
        const string TYPE = "Assistent";
        public Assistent(string brand, bool isFunctioning): base(brand, isFunctioning)
        {            
            this.Type = TYPE;
        }
    }
}
