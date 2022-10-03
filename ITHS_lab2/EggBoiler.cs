using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class EggBoiler : Appliance
    {
        const string TYPE = "Äggkokare";
        public EggBoiler(string brand, bool isFunctioning) : base(brand, isFunctioning)
        {
            this.Type = TYPE;
        }
    }
}
