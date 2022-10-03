using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace ITHS_lab2
{
    /// <summary>
    /// The main program holds a List of type Kitchen.
    /// The user can add new kitchens, delete kitchens, and chose
    /// to enter any of the created kitchens to manage them in the
    /// next menu. User can go back and forth from different kitchens.
    /// </summary>
    class Program
    {
        static List<Kitchen> allKitchens = new List<Kitchen>();
        static void Main(string[] args)
        {
            // Displays title and menu control until user terminates the program
            while (true)
            {
                Console.Clear();
                FancyTitle();
                KitchenMenuControl();
            }
        }

        /// <summary>
        /// Show menu and excecute the choise
        /// </summary>
        private static void KitchenMenuControl()
        {
            // Show all kitchens
            int menuChoise;
            for (int i = 0; i < allKitchens.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allKitchens[i].KitchenName}");
            }

            int minChoise = 1;  
            if (allKitchens.Count == 0)
            {
                Console.WriteLine("\nDet finns inga kök skapade än\n");
                minChoise = 2;      // You can't choose to enter any kitchen if there are none
            }
            else Console.WriteLine("\n\n1. Välj kök att gå in i");      // Enter one of the created kitchens
            Console.WriteLine("2. Lägg till nytt kök och gå in");       // Create a new kitchen (auto enter)
            Console.WriteLine("3. Ta bort kök");                        // Remove a kitchen from the list
            Console.WriteLine("4. Avsluta program");                    // Terminate the program
            Console.Write("\nVälj > ");

            // Call the input control with max and min perimeters (menu choises)
            menuChoise = UserInput(minChoise, 4);

            switch (menuChoise)
            {
                case 1:
                    Console.Write("Välj kök från listan ovan > ");
                    int kitchenChoise = UserInput(1, allKitchens.Count);
                    allKitchens[kitchenChoise-1].MenuControl();
                    break;
                case 2:
                    Console.Write("\nLägg till kök - Ange kökets namn > ");
                    allKitchens.Add(new Kitchen(Console.ReadLine()));
                    break;
                case 3:
                    DeleteKitchen();
                    break;
                case 4:
                    Environment.Exit(1);
                    break;
            }
        }

        /// <summary>
        /// Control what the user enters.
        /// </summary>
        /// <param name="min">The minimum allowed choise</param>
        /// <param name="max">The maximum allowed choise</param>
        /// <returns>Integer within the perimeters</returns>
        private static int UserInput(int min, int max)
        {
            bool valid;
            int choise;
            do
            {
                string inp = Console.ReadLine();
                valid = false;
                valid = Int32.TryParse(inp, out choise) && choise >= min && choise <= max;
                if (!valid)
                    Console.Write("Try again > ");
            } while (!valid);
            return choise;
        }


        /// <summary>
        /// Delete one kitchen from the list
        /// </summary>
        private static void DeleteKitchen()
        {
            if (allKitchens.Count == 0)
            {
                Console.WriteLine("Det finns inga kök att ta bort!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine();
            ShowAllKitchens();
            Console.Write("\nVälj kök att ta bort > ");
            int deleteKitchen = UserInput(1, allKitchens.Count);
            allKitchens.RemoveAt(deleteKitchen - 1);
            Console.WriteLine("\nKök borttaget.");
        }


        private static void ShowAllKitchens()
        {
            for (int i = 0; i < allKitchens.Count; i++)
                Console.WriteLine($"{i + 1}. {allKitchens[i].KitchenName}");
        }


        /// <summary>
        /// Display a (fancy) animated title for a few seconds
        /// </summary>
        private static void FancyTitle()
        {
            const string TEXT = "             KÖKSSIMULATOR";   // The text to roll from right to left
            const int TITLE_ROLL_SPEED = 40;                    // The duration between frames
            const int STRING_LENGTH = 26;                       // The total length of the string inlc. spaces
            const int NUM_OF_ROTATION_FRAMES = 4;               // The number of symbols to simulate rotation - \ | \

            // Iterate through the different sets of symbols to simulate rotation
            string[] allRows = { "////////////////////////////", "----------------------------",
                "\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\", "||||||||||||||||||||||||||||" };
            string[] single = { "/", "-", "\\", "|" };

            for (int laps = 0; laps < 3; laps++)    // Play animation 3 times
            {
                Console.CursorVisible = false;
                for (int i = 0; i < STRING_LENGTH; i++)
                {
                    Console.SetCursorPosition(0, 1);

                    // Print each set of symbols every 4th iteration
                    Console.WriteLine(allRows[i % NUM_OF_ROTATION_FRAMES]);
                    Console.Write(single[i % NUM_OF_ROTATION_FRAMES]);
                    Console.Write(TEXT.Substring(i) + TEXT.Substring(0, i));
                    Console.WriteLine(single[i % NUM_OF_ROTATION_FRAMES]);
                    Console.WriteLine(allRows[i % NUM_OF_ROTATION_FRAMES]);
                    Thread.Sleep(TITLE_ROLL_SPEED);

                    // Make the text stop centered in the square
                    if (laps == 2 && i == 7)
                        break;
                }
            }
        }
    }
}
