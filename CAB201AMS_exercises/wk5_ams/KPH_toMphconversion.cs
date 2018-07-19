// write a program to create a table for converting from miles per hour to kilometres per hour. 
// program must start at 3mph and increase by 7mph each time, and show a total of exactly 12 lines not including the column 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SpeedConversion
{
    class MilesPerHourTable
    {
        public static void Main()
        {
            // Write your code to create the MPH to KPH table here
            int mph=3;
            double kph;
            double formula = 1 / 0.62137;
            string result ="MPH" + "\t" + "KPH" + "\n";
            //Console.WriteLine(result);
            int counter = 0;
            while (counter < 12)
            {
                kph = mph * formula;
                result += mph + "\t" + string.Format("{0:0.00}",kph) + "\n";
                mph += 7;
                counter++;


            }
            Console.WriteLine(result);



            Console.WriteLine("\n\n Hit Enter to exit.");
            Console.ReadLine();
        }
    }
}