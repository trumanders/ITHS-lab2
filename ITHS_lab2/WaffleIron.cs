using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class WaffleIron : Appliance
    {
        const string TYPE = "Våffeljärn";
        public WaffleIron(string brand, bool isFunctioning) : base(brand, isFunctioning)
        {
            this.Type = TYPE;   
        }          
    }
}
