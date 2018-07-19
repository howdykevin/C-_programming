// a program that asks the user to enter a number between 1 and 10. Then display the number provided by the user in Roman numerals.
// using System;

namespace RomanNumerals
{
    class RomanNumeralConverter
    {
        public static void Main()
        {
            // Write your program to convert numbers into Roman numerals here
            DisplayMenu();
            //int numbers = number();
            romanNumberConversion(Number());

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static void DisplayMenu()
        {
            Console.Write("Please type in a number between 1 and 10: ");
        }

        public static int Number()
        {
            int userInput;
            bool options;
            do
            {
                string input = Console.ReadLine();
                options = int.TryParse(input, out userInput);
                if (!options || userInput < 0 || userInput > 10)
                {
                    Console.WriteLine("Please enter a number");
                    options = false;
                    DisplayMenu();

                }
                else
                {
                    options = true;
                    break;
                }
            } while (!options);
            return userInput;


        }

        public static void romanNumberConversion(int numbers)
        {
            switch (numbers)
            {
                case 1:
                    Console.WriteLine("1 in Roman numerals is I");
                    break;
                case 2:
                    Console.WriteLine("2 in Roman numerals is II");
                    break;
                case 3:
                    Console.WriteLine("3 in Roman numerals is III");
                    break;
                case 4:
                    Console.WriteLine("4 in Roman numerals is IV");
                    break;
                case 5:
                    Console.WriteLine("5 in Roman numerals is V");
                    break;
                case 6:
                    Console.WriteLine("6 in Roman numerals is VI");
                    break;
                case 7:
                    Console.WriteLine("7 in Roman numerals is VII");
                    break;
                case 8:
                    Console.WriteLine("8 in Roman numerals is VIII");
                    break;
                case 9:
                    Console.WriteLine("9 in Roman numerals is IX");
                    break;
                case 10:
                    Console.WriteLine("10 in Roman numerals is X");
                    break;



            }
        }
    }
}