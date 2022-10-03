using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{
    class Toaster : Appliance
    {
        const string TYPE = "Brödrost";
        public Toaster(string brand, bool isFunctioning) : base(brand, isFunctioning)
        {
            this.Type = TYPE;
        }
    }
}
