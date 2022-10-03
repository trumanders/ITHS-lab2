using System;
using System.Globalization;
using System.Threading;

namespace ITHS_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play title animation
            FancyTitle();
            bool valid;
            int numOfAppliances;
            do
            {                
                Console.Write("\nHur många köksapparater klarar ditt kök? > ");
                valid = Int32.TryParse(Console.ReadLine(), out numOfAppliances) && numOfAppliances > 0;
            } while (!valid);
            Kitchen kitchen1 = new Kitchen(numOfAppliances);
        }


        private static void FancyTitle()
        {
            const string TEXT = "             KÖKSSIMULATOR";
            const int TITLE_ROLL_SPEED = 50;
            const int STRING_LENGTH = 26;
            const int NUM_OF_ROTATION_FRAMES = 4;
            string[] allRows = { "////////////////////////////", "----------------------------",
                "\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\", "||||||||||||||||||||||||||||" };
            string[] single = { "/", "-", "\\", "|" };

            for (int laps = 0; laps < 3; laps++)
            {
                Console.CursorVisible = false;
                for (int i = 0; i < STRING_LENGTH; i++)
                {
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine(allRows[i % NUM_OF_ROTATION_FRAMES]);
                    Console.Write(single[i % NUM_OF_ROTATION_FRAMES]);
                    Console.Write(TEXT.Substring(i) + TEXT.Substring(0, i));
                    Console.WriteLine(single[i % NUM_OF_ROTATION_FRAMES]);
                    Console.WriteLine(allRows[i % NUM_OF_ROTATION_FRAMES]);
                    Thread.Sleep(TITLE_ROLL_SPEED);
                    if (laps == 2 && i == 7)
                        break;
                }
            }
        }
    }
}
