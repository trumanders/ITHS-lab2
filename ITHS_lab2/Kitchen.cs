using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace ITHS_lab2
{
    /// <summary>
    /// The kithcen holds:
    /// List of appliances
    /// Max number of appliances
    /// </summary>
    class Kitchen
    {
        /// <summary>
        /// The Kitchen class contains the menus, and the list
        /// of appliances. The Kitchen controls the appliances.
        /// </summary>

        private int maxNumOfAppliances;
        public List<Appliance> allAppliances = new List<Appliance>();
        const string TITLE = "||||||||||||||||||||||||||||\n|      KÖKSSIMULATOR       |\n" +
            "||||||||||||||||||||||||||||";

        public Kitchen(int numOfAppliances)
        {
            this.maxNumOfAppliances = numOfAppliances;
            // Add appliances upon start
            allAppliances.Add(new Assistent("Electrolux", true));
            allAppliances.Add(new CoffeMaker("Moccamaster", true));
            allAppliances.Add(new EggBoiler("Emerio", true));
            allAppliances.Add(new ElectricKettle("Bosch",true));
            allAppliances.Add(new Microwave("Samsunng", true));
            allAppliances.Add(new Toaster("Philips", true));
            allAppliances.Add(new WaffleIron("Wilfa", true));
            MenuControl();
        }

        public void MenuControl()
        {

            int menuChoise;
            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(TITLE);
                Console.SetCursorPosition(0, 5);                
                Console.WriteLine("\n1. Använd köksapparat");
                Console.WriteLine("2. Lägg till köksapparat");
                Console.WriteLine("3. Lista köksapparater");
                Console.WriteLine("4. Ta bort köksapparat");
                Console.WriteLine("5. Avsluta");
                menuChoise = UserInput(1, 5);

                switch (menuChoise)
                {
                    case 1:
                        Console.WriteLine("Använd köksapparat");
                        UseAppliace();
                        break;
                    case 2:
                        Console.WriteLine("2. Lägg till köksapparat");
                        AddAppliance();
                        break;
                    case 3:
                        Console.WriteLine("3. Lista köksapparater");
                        ListAppliances();
                        break;
                    case 4:
                        Console.WriteLine("4. Ta bort köksapparat");
                        DeleteAppliance();
                        break;
                    case 5:
                        Console.WriteLine("5. Stäng kök");
                        return;
                }
                Console.ReadKey();
            } while (menuChoise != 5);
        }


        private int UserInput(int min, int max)
        {
            bool valid;
            int inp;
            do
            {
                Console.Write("\nVälj > ");
                valid = Int32.TryParse(Console.ReadLine(), out inp) && inp >= min && inp <= max;

            } while (!valid);
            return inp;
        }



        public void UseAppliace()
        {
            // Show list of appliance to select

        }


        public void AddAppliance()
        {

        }


        public void ListAppliances()
        {
            foreach (Appliance appliance in allAppliances)
            {
                appliance.ShowApplianceInfo();
            }
            
        }       


        public void DeleteAppliance()
        {
            
        }


        //MENU
        /* 1. använd apparat
         *      Välj apparat från lista
         *          skriv ut: används eller trasig
         *          val att gå tillbaka till huvudmeny
         * 
         * 2. lägg till apparat
         *      märke, skick ("j" = funkar, annars trasig)
         *      meddela att apparat lagts till
         *      val att gå tillbaka
         *      
         * 3. lista apparater
         *      skriv ut lista över alla apparater
         *      skriv med typ, märke och skick
         *      val att gå tillbaka
         *      
         * 4. ta bort apparat
         *      skriv ut numrerad lista, välj apparat att ta bort
         *      meddela att den tagits bort
         *      val att gå tillbaka
         *      
         * 5. avsluta program
         * 
         * SKA FINNAS:
         * variabler
         * properties (get, set)
         * typkonvertering
         * felhantering med try-catch
         * klasser
         * abstrakt klass
         * interface, kan utökas
         * inkapsling
         * metoder
         * iterering
         * selektion
         */

    }
}

