using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class ElectricKettle : Appliance
    {
        const string TYPE = "Vattenkokare";
        public ElectricKettle(string brand, bool isFunctioning) : base(brand, isFunctioning)
        {
            this.Type = TYPE;
        }
    }
}
