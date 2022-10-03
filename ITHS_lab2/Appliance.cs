using System;
using System.Collections.Generic;
using System.Text;

namespace ITHS_lab2
{      
    abstract class Appliance : IKitchenAppliance
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        public string functioningStr;

        public Appliance(string brand, bool isFunctioning)
        {
            this.Type = SetType(this.GetType().ToString());
            Brand = brand;
            IsFunctioning = isFunctioning;
            if (isFunctioning) functioningStr = "Fungerar";
            else functioningStr = "Trasig";
        }


        /// <summary>
        /// Is called when the user choses to use an appliance
        /// </summary>
        public void Use()
        {
            if (IsFunctioning) Console.WriteLine("\nAnvänder apparaten...");
            else Console.WriteLine("\nApparaten är trasig");
        }


        /// <summary>
        /// Sets the Type-property based on the current object's type.
        /// </summary>
        /// <param name="type">The object's type in string format</param>
        /// <returns>Formated version of the object's type</returns>
        private string SetType(string type)
        {
            switch (type)
            {
                case "ITHS_lab2.Assistent":
                    return "Assistent";
                case "ITHS_lab2.CoffeMaker":
                    return "Kaffebryggare";
                case "ITHS_lab2.EggBoiler":
                    return "Äggkokare";
                case "ITHS_lab2.ElectricKettle":
                    return "Vattenkokare";
                case "ITHS_lab2.Microwave":
                    return "Mikrovågsugn";
                case "ITHS_lab2.Toaster":
                    return "Brödrost";
                case "ITHS_lab2.WaffleIron":
                    return "Våffeljärn";
                default: return null;
            }
        }
    }
}
