using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class CoffeMaker : Appliance
    {
        const string TYPE = "Kaffebryggare";
        public CoffeMaker(string brand, bool isFunctioning) :base(brand, isFunctioning)
        {
            this.Type = TYPE;
        }
    }
}
