// takes a temperature in degrees Celsius from the user and displays the same temperature in degrees Fahrenheit;
// The code contains no input validation. The only requirement is that, if you enter a valid number, it should display the correct converted temperature.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SimpleTempConversion
{
    
    class CelsiusToFahrenheit
    {
        public static void Main()
        {
            double celsius = 0.0;

            //input the temperature in degrees Celsius
            Console.Write("Enter degrees Celsius: ");
            celsius = int.Parse(Console.ReadLine());

            // Calculate degrees Fahrenheit and output the result
            Console.WriteLine("\n\nThe equivalent in Fahrenheit is " + ((celsius / 5) * 9 + 32));

            Console.WriteLine("\n\n Hit Enter to exit.");
            Console.ReadLine();
        }
    }
}