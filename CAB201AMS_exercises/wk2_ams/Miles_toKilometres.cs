// converting miles to kilometres.

using System;

namespace SimpleLengthConversion
{
    public class MilesToKm
    {
        public static void Main()
        {
            double miles = 0.0;
            double kilometres;
            miles = InputMiles();
            kilometres = MilesToKilometres(miles);
            OutputResult(miles, kilometres);
            ExitProgram();
        }

        public static double InputMiles()
        {
            // Ask the user to type in a number in miles
            Console.Write("How many miles?");

            // Return the number the user typed in
            double miles = int.Parse(Console.ReadLine());
            return miles;
        }

        public static double MilesToKilometres(double miles)
        {
            // Return the value 'miles' converted to kilometres
            double kilometres = miles * 1.609344;
            return kilometres;
        }

        public static void OutputResult(double miles, double kilometres)
        {
            // Display the message "(miles) miles is equal to (kilometres) kilometres"
            Console.WriteLine(miles + " miles is equal to " + kilometres + " kilometres");
        }

        public static void ExitProgram()
        {
            // Prompt the user to press enter to close the window
            Console.WriteLine("Press enter to exit");

            // Wait for the user to press enter
            Console.ReadLine();
        }
    }
}