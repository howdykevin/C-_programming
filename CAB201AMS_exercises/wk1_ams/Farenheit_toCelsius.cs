// write a program that takes a temperature (given in degrees Fahrenheit) from the user, 
// then convert that temperature into degrees Celsius and display it to the user.

using System;

namespace SimpleTempConversion
{
    public class FahrenheitToCelsius
    {
        public static void Main()
        {
            // Declare a variable to hold the temperature obtained from the user
            int tempF;

            // Declare a variable to hold the converted temperature
            double tempC;

            // Display "What is the temperature (in degrees Fahrenheit): "
            Console.Write("What is the temperature (in degrees Fahrenheit): ");

            // Read the current Fahrenheit temperature from the user
            tempF = int.Parse(Console.ReadLine());

            // Convert the Fahrenheit temperature into degrees Celsius
            tempC = (tempF - 32)*(5.0/9.0);

            // Display "The temperature is (temperature here) degrees Celsius"
            // Remember to replace (temperature here) with the Celsius temperature
            Console.Write("The temperature is " + tempC + " degrees Celsius");

            // Prompt the user to press enter to close the window
            Console.Write("Press enter to exit.");
            Console.ReadLine();
        }
    }
}