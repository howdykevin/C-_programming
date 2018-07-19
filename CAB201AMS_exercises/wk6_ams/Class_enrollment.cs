// a program designed to show a list of the enrolment levels of different classes
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
            int[] currentEnrolment = new int[] { 11, 9, 12, 12, 11 };
            int[] maximumEnrolment = new int[] { 23, 29, 25, 28, 25 };

            Console.WriteLine("Number of places still available for each class.\n");

            // Write a "for" loop here, using the className.Length property.
            // Do not change any of the existing lines of code.
            // ...
            // ...
            // ...
            for(int i = 0; i < className.Length; i++)
            {
                
                Console.WriteLine("{0} has a current enrolment of {1} and a maximum of {2}.",className[i],currentEnrolment[i],maximumEnrolment[i]);

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