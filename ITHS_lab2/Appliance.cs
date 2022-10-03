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
        private string functioningStr;

        public Appliance() {}

        public Appliance(string brand, bool isFunctioning)
        {
            this.Type = SetType(this.GetType().ToString());
            Brand = brand;
            IsFunctioning = isFunctioning;
            if (isFunctioning) functioningStr = "Fungerar";
            else functioningStr = "Trasig";
        }

        public void Use()
        {

        }

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

        public void ShowApplianceInfo()
        {
            Console.WriteLine(Type);
            Console.WriteLine(Brand);
            Console.WriteLine(functioningStr);
        }
    }
}
