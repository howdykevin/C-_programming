// a program designed to show the number of enrolment positions open for each class, or display that the class is full if that is the case.
/* This program uses three parallel
 * arrays to display the class name 
 * and how many places are left in that
 * class.
 */
using System;

namespace ClassEnrolment
{

    class ClassEnrolment
    {

        public static void Main()
        {

            string[] className = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            int[] currentEnrolment = new int[] { 35, 20, 33, 20, 32 };
            int[] maximumEnrolment = new int[] { 40, 24, 33, 22, 33 };

            Console.WriteLine("Number of places still available for each class.\n");

            // Write a "for" loop here, using the className.Length property.
            // Do not change any of the existing lines of code.
            // ...
            // ...
            // ...
            for(int i = 0; i < className.Length; i++)
            {
                if (maximumEnrolment[i] - currentEnrolment[i] > 0)
                {
                    Console.WriteLine("{0} has {1} places left.", className[i], maximumEnrolment[i] - currentEnrolment[i]);
                }
                else
                {
                    Console.WriteLine("{0} is full.", className[i]);
                }
            }

            ExitProgram();
        }

        public static void ExitProgram()
        {
            Console.Write("Press enter to continue ...");
            Console.ReadLine();
        }
    }
}