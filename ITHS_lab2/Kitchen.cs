using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace ITHS_lab2
{
    /// <summary>
    /// Each instace of Kitchen has a list of appliances, and
    /// handles menus, listing, adding, and deleting of appliances
    /// for that kitchen. User can use, add, list, and remove
    /// kitchen appliances from the kitchen. User can exit the
    /// kitchen and go back to choose another kitchen to work on.
    /// </summary>
    class Kitchen
    {
        public string KitchenName { get; set; }
        public List<Appliance> allAppliances = new List<Appliance>();
        const string TITLE = "||||||||||||||||||||||||||||\n|      KÖKSSIMULATOR       |\n" +
            "||||||||||||||||||||||||||||";

        public Kitchen(string name)
        {
            this.KitchenName = name;
            // Add appliances upon start
            allAppliances.Add(new Assistent("Electrolux", true));
            allAppliances.Add(new CoffeMaker("Moccamaster", true));
            allAppliances.Add(new EggBoiler("Emerio", true));
            allAppliances.Add(new ElectricKettle("Bosch", true));
            allAppliances.Add(new Microwave("Samsunng", true));
            allAppliances.Add(new Toaster("Philips", true));
            allAppliances.Add(new WaffleIron("Wilfa", true));
            MenuControl();
        }


        /// <summary>
        /// Lets the user choose from the different functionality, and 
        /// calls the corresponding methods.
        /// </summary>
        public void MenuControl()
        {
            int menuChoise;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(TITLE);
                Console.WriteLine("\nDU ÄR INNE I KÖK:");
                Console.WriteLine($"\n--== {KitchenName} ==--");
                //Console.SetCursorPosition(0, 5);
                Console.WriteLine("\n1. Använd köksapparat");
                Console.WriteLine("2. Lägg till köksapparat");
                Console.WriteLine("3. Lista köksapparater");
                Console.WriteLine("4. Ta bort köksapparat");
                Console.WriteLine("5. Gå ut ur kök");
                menuChoise = UserInput(1, 5);

                switch (menuChoise)
                {
                    case 1:
                        UseAppliace();
                        break;
                    case 2:
                        AddAppliance();
                        break;
                    case 3:
                        ShowAllAppliances();
                        break;
                    case 4:
                        DeleteAppliance();
                        break;
                    case 5:
                        return;
                }
                Console.ReadKey();
            } while (menuChoise != 5);
        }


        /// <summary>
        /// Controls what the user can enter for different
        /// tasks.
        /// </summary>
        /// <param name="min">The minimum allowed integer.</param>
        /// <param name="max">The maximum allowed integer.</param>
        /// <returns>An integer between min and max</returns>
        private int UserInput(int min, int max)
        {
            int inp;
            do
            {
                Console.Write("\nVälj > ");
            } while (!Int32.TryParse(Console.ReadLine(), out inp) || inp < min || inp > max);
            return inp;
        }


        /// <summary>
        /// Use the selected appliance.
        /// </summary>
        public void UseAppliace()
        {
            Console.Clear();
            Console.WriteLine("\nANVÄND KÖKSAPPARAT");
            Console.WriteLine("-------------------");
            ShowAllAppliances();
            int useChoise = UserInput(1, allAppliances.Count);
            allAppliances[useChoise - 1].Use();
        }


        /// <summary>
        /// Add a new appliance to the list of appliances
        /// </summary>
        private void AddAppliance()
        {
            ShowAddMenu();
            int typeChoise = UserInput(1, 7);
            Console.Write("\nAnge märke > ");
            string brand = Console.ReadLine();
            string answer;
            bool isFunctioning = true;
            do
            {
                Console.Write("Fungerar apparaten? (j/n) > ");
                answer = Console.ReadLine();
                if (answer == "j") isFunctioning = true;
                else if (answer == "n") isFunctioning = false;
                else Console.WriteLine("Ange \"j\" eller \"n\"");
            } while (answer != "j" && answer != "n");

            switch (typeChoise)
            {
                case 1:
                    allAppliances.Add(new Assistent(brand, isFunctioning));
                    break;
                case 2:
                    allAppliances.Add(new CoffeMaker(brand, isFunctioning));
                    break;
                case 3:
                    allAppliances.Add(new EggBoiler(brand, isFunctioning));
                    break;
                case 4:
                    allAppliances.Add(new ElectricKettle(brand, isFunctioning));
                    break;
                case 5:
                    allAppliances.Add(new Microwave(brand, isFunctioning));
                    break;
                case 6:
                    allAppliances.Add(new Toaster(brand, isFunctioning));
                    break;
                case 7:
                    allAppliances.Add(new WaffleIron(brand, isFunctioning));
                    break;
            }
            Console.WriteLine("\nKöksapparat tillagd:\n");
            Console.WriteLine($"{brand} {allAppliances[allAppliances.Count - 1].Type}");
        }


        /// <summary>
        /// Select and delete one appliance.
        /// </summary>
        public void DeleteAppliance()
        {
            Console.Clear();
            Console.WriteLine("\nTA BORT KÖKSAPPARAT");
            Console.WriteLine("-------------------");
            ShowAllAppliances();
            int deleteChoise = UserInput(1, allAppliances.Count);

            // Save info to display after deleting object
            string brand = allAppliances[deleteChoise - 1].Brand;
            string type = allAppliances[deleteChoise - 1].Type;

            // Delete chosen appliance
            allAppliances.RemoveAt(deleteChoise - 1);
            Console.WriteLine("\nKöksapparat borttagen:\n");

            // Display the deleted appliance
            Console.WriteLine($"{brand} {type}");
        }


        /// <summary>
        /// Let user choose from the different types to add one appliance
        /// </summary>
        private void ShowAddMenu()
        {
            Console.Clear();
            Console.WriteLine("\nLÄGG TILL KÖKSAPPARAT");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Assistent");
            Console.WriteLine("2. Kaffebryggare");
            Console.WriteLine("3. Äggkokare");
            Console.WriteLine("4. Vattenkokare");
            Console.WriteLine("5. Mikrovågsugn");
            Console.WriteLine("6. Brödrost");
            Console.WriteLine("7. Våffeljärn");
        }


        /// <summary>
        /// Displays a list of all current appliances in the list.
        /// </summary>
        private void ShowAllAppliances()
        {
            Console.WriteLine();
            for (int i = 0; i < allAppliances.Count; i++)
                Console.WriteLine($"{i + 1}. {allAppliances[i].Brand,-20} {allAppliances[i].Type,-20} {allAppliances[i].functioningStr}");
        }
    }
}
