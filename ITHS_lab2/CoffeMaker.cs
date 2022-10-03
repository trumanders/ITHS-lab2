using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class CoffeMaker : Appliance
    {
        const string TYPE = "Kaffebryggare";
        private float waterCapacity;
        private bool autoOff;
        private int numberOfCups;

        public CoffeMaker(string brand, bool isFunctioning) :base(brand, isFunctioning)
        {
            this.Type = TYPE;
        }
    }
}
