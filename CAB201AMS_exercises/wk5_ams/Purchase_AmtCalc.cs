// create a console application that allows for the calculation of the total amount due for purchases. This application should allow any number of items to be entered, and should then determine the total due including sales tax and shipping. The following rules are used to determine the amount due.
// There is a global sales tax of 10.0%.
// Shipping charges are determined based on the number of items order. 
// less than 3 - $3.50 
// between 3 and 6 - $5.00 
// between 7 and 10 - $7.00 
// between 11 and 15 - $9.00 
// more than 15 - $10.00
// If the user enters a non-numeric input for the price of an item, they should be prompted to re-enter.
// If the user enters a negative input for the price of an item, they should be prompted to re-enter.
// An item price of $0 is okay.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PurchaseApp
{
    class PurchaseCalc
    {
        public static void Main()
        {
            // You aren't provided with any example code for this exercise
            // Your task is to write this program from scratch
            Console.Write("This application computes the total due for your purchases.\nIt will allow you to enter any number of purchase amounts, and then display a receipt.\n\nPress enter when you are ready to begin...\n");
            Console.ReadLine();
            double purchase = 0;
            double tax;
            double stax;
            int total=0;
            double grand=0.0;
            purchase += PhaseOne();
            total += 1;
            char ans;
            do
            {
                Console.Write("Do you want to enter more purchases? - Y or N ");
                ans = Char.Parse(Console.ReadLine());
                if (ans == 'Y' || ans == 'y')
                {
                    purchase += PhaseOne();
                    total += 1;

                }
                else if (ans == 'N' || ans == 'n')
                {
                    tax = PhaseTwo(purchase);
                    stax = PhaseThree(total);
                    grand = tax + stax + purchase;
                    Console.WriteLine("-----------------------------------------");
                    //Console.WriteLine("");
                    Console.WriteLine("\t" + "Sales Receipt" + "\t");
                    //Console.WriteLine("");
                    Console.WriteLine("Total Purchases:           {0:c}", purchase);
                    Console.WriteLine("Sales Tax:                  {0:c}", tax);
                    Console.WriteLine("Number of Items Purchased:      "+ total);
                    Console.WriteLine("Shipping charge:            {0:c}", stax);
                    //Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------");
                    //Console.WriteLine("");

                    Console.WriteLine("Grand Total:               {0:c}", grand);
                    

                }
            } while (ans == 'Y' || ans == 'y');
            



            Console.WriteLine("\n\n Hit Enter to exit.");
            Console.ReadLine();
        }

        public static double PhaseOne()
        {
            bool response;
            double cost;
            Console.Write("What is the amount of the item? - ");
            do
            {
                response = Double.TryParse(Console.ReadLine(), out cost);
                if (response == false || cost < 0.0)
                {
                    Console.Write("Invalid data entered - Please re-enter the amount of item - ");
                    //response = Double.TryParse(Console.ReadLine(), out cost);
                }
            } while (response == false || cost < 0.0);
            return cost;

        }

        public static double PhaseTwo(double money)
        {
            money *= 0.10;
            return money;
        }

        public static double PhaseThree(int number)
        {
            double shiptax;
            if (number < 3)
            {
                shiptax = 3.50;
            }
            else if (number>=3 && number<=6)
            {
                shiptax = 5.00;
            }
            else if(number>=7 && number <= 10)
            {
                shiptax = 7.00;
            }
            else if(number>=11 && number <= 15)
            {
                shiptax = 9.00;
            }
            else
            {
                shiptax = 10.00;
            }
            return shiptax;
        }




    }
}