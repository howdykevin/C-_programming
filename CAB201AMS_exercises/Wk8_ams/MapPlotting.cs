// asked to write an application that allows the user to input the coordinates of points on a map. After the user has input all the coordinates they want to input, the program then displays a text-based map, filled with dots (represented by the '.' character), except for the locations the user entered the coordinates of, which are indicated by 'X' characters.
// The program collects input from the user by asking the user to input the X coordinate first, followed by the Y coordinate, followed by 'y' or 'n' to ask the user if there are any more points to be entered.
// After the user has indicated (by responding 'n' on the third question) that there are no more points, the program should display the map, ask the user to press enter to exit, then close when the user presses enter.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapPlotting
{
    class Program
    {
        public static void Main()
        {
            // Write your program here
            // ...
            int X;
            int Y;
            bool test;
            string[,] map = new string[20, 43];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 43; j++)
                {
                    map[i, j] = ".";
                }
            }

            do
            {
                X = markerX();
                Y = markerY();
                map.SetValue("X", Y, X);
                test = More();

            } while (test != false);

            for (int v = 0; v < 20; v++)
            {
                for (int z = 0; z < 43; z++)
                {
                    Console.Write(map[v, z]);
                    //z!=0 as 0%42 will give you 0
                    if (z % 42 == 0 && z!=0)
                    {
                        Console.WriteLine();
                    }

                }
            }


            Console.WriteLine();
            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        public static int markerX()
        {
            int xCoord;
            bool result;
            //what is the x coord
            do
            {
                Console.Write("Place a marker at which X coordinate? (0-42): ");
                result = int.TryParse(Console.ReadLine(), out xCoord);
                if (result != true)
                {
                    Console.WriteLine("Invalid input.");
                    result = false;
                }
                else if (xCoord < 0 || xCoord > 42)
                {
                    Console.WriteLine("Out of range.");
                    result = false;
                }
            } while (result != true);
            return xCoord;
        }

        public static int markerY()
        {
            int yCoord;
            bool output;
            do
            {
                Console.Write("Place a marker at which Y coordinate? (0-19): ");
                output = int.TryParse(Console.ReadLine(), out yCoord);
                if (output != true)
                {
                    Console.WriteLine("Invalid input.");
                    output = false;
                }
                else if (yCoord < 0 || yCoord > 19)
                {
                    Console.WriteLine("Out of range.");
                    output = false;
                }
            } while (output != true);
            return yCoord;
        }

        public static bool More()
        {
            //bool rerun;
            bool again;
            char character;
            do
            {
                Console.Write("More? (y/n): ");
                again = char.TryParse(Console.ReadLine(), out character);
                if (character != 'n' || character != 'y')
                {
                    Console.WriteLine("Please answer with y or n.");
                    again = false;
                }
                if (character == 'y')
                {
                    again = true;
                    return true;
                }
                else
                {
                    again = true;
                    return false;
                }

            } while (again != true);

        }

    }
}