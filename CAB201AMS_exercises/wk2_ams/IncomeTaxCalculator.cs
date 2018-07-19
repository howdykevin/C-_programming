// a program which will ask the user initially for their total income, which will be a whole dollar amount followed by the number of children that they have and the program will output the amount of tax that the user will be required to pay.
// If the user enters a negative income value, ask the user to re-enter their income. The same is true if the user enters a non-numeric value.
// An income of $0 is okay.
// If the user enters a negative or non-numeric number of children, ask the user to re-enter their number of children.
// If the amount of tax payable is a negative amount or zero, then output "You owe no tax."

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncomeTaxCalculator
{
    class IncomeTax
    {
        public static void Main()
        {
            // You aren't provided with any example code for this exercise
            // Your task is to write this program from scratch
            int income;
            int child;
            income = Income();
            child = Kids();
            Tax(income, child);

            Console.WriteLine("\n\n Hit Enter to exit.");
            Console.ReadLine();
        }

        public static int Income()
        {
            int income;
            bool result;
            // How much income
            do
            {
                Console.Write("What is your total income: ");
                result = int.TryParse(Console.ReadLine(), out income);
                if (result != true)
                {
                    Console.WriteLine("Enter your income as a whole-dollar numeric figure.");
                    result = false;
                }
                else if (income < 0)
                {
                    Console.WriteLine("Your income cannot be negative.");
                    result = false;
                }
            } while (result != true);

            return income;


        }

        public static int Kids()
        {
            int child;
            bool loop;
            //How many children
            do
            {
                Console.Write("How many children do you have: ");

                loop = int.TryParse(Console.ReadLine(), out child);
                if (loop != true)
                {
                    Console.WriteLine("You must enter a valid number.");
                    loop = false;
                }
                else if (child < 0)
                {
                    Console.WriteLine("You must enter a positive number.");
                    loop = false;
                }

            }while (loop != true) ;



            return child;
        }

        public static void Tax(int income, int child)
        {
            // income after deductables
            int deduct = child * 2000;
            int money = income - 10000 - deduct;
            //Tax needed
            double tax = money * 0.02;
            if (tax <= 0.0)
            {
                Console.WriteLine("You owe no tax.");
            }
            else
            {
                Console.WriteLine("You owe a total of " + tax + " tax");
            }

        }

    }
}
