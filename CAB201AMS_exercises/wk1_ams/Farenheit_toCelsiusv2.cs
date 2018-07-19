// program more robust by making it check that the text entered is actually a number.

// If the user enters something other than a number, your program should report "Invalid input" and ask for a number again. It should continue displaying "Invalid input" until a number is entered, 
// and then convert that temperature to Celsius.

using System;

namespace SimpleTempConversion
{
    public class FahrenheitToCelsiusV2
    {
        public static void Main()
        {
            // Declare a variable of type 'double' to hold the temperature obtained from the user
            double tempF;

            // Declare a variable of type 'double' to hold the converted temperature
            double tempC;

            // Declare a bool to record if the user has entered in a valid number yet
            bool b=true;

            do
            {
                // Display "What is the temperature (in degrees Fahrenheit): "
                Console.Write("What is the temperature (in degrees Fahrenheit): ");

                // Use TryParse() to read the Fahrenheit temperature. Set the bool variable
                // declared earlier to the result of TryParse()
                b = double.TryParse(Console.ReadLine(), out tempF);


                // Check the bool variable to see if TryParse() failed to parse
                if (b == false)
                {
                    // Display "Invalid input" on a line by itself.
                    Console.Write("Invalid input");
                    Console.WriteLine();
                }

                // The code should loop while the input is not valid
            } while (b == false);

            // Convert the Fahrenheit temperature into degrees Celsius
            tempC = (tempF - 32) * (5.0 / 9.0);

            // Display "The temperature is (temperature here) degrees Celsius"
            // Remember to replace (temperature here) with the Celsius temperature
            Console.Write("The temperature is " + tempC + " degrees Celsius");
            Console.WriteLine();

            // Prompt the user to press enter to close the window
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}