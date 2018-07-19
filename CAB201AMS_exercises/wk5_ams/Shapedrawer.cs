// write a class to draw shapes of varying sizes. This class should include two methods - one to draw hollow squares, and another to draw isosceles triangles.
// #####
// #   #
// #   #
// #####
// -
// --
// ---
// --
// -

using System;

namespace Shapes
{
    public class ShapeDrawer
    {
        public static void Main()
        {
            Console.WriteLine(DrawSquare(7, -1));
            Console.WriteLine(DrawSquare(4, 5));
            Console.WriteLine(DrawIsoscelesTriangle(6));
            Console.ReadLine();
        }


        private static int h;
        private static int w;
        private static int s;

        public static int H { get => h; set => h = value; }
        public static int W { get => w; set => w = value; }
        public static int S { get => s; set => s = value; }

        public static string DrawSquare(int height, int width)
        {
            // Write your code to draw the square here
            string result = "";
            H = height;
            W = width;

            if (H < 1 || W < 1)
            {
                Console.WriteLine("Cannot draw that shape.");
            }

            for (int y = 0; y < H; y++)
            {

                for (int i = 0; i < W; i++)
                {

                    if (y > 0 && y < H - 1 && i > 0 && i < W - 1)
                    {
                        result += " ";
                    }
                    else
                    {
                        result += "#";
                    }

                }
                result += "\n";


            }

            return result;

        }

        public static string DrawIsoscelesTriangle(int size)
        {
            // Write your code to draw the triangle here
            string triangle = "";
            S = size;
            if (S < 2)
            {
                Console.WriteLine("Cannot draw that shape.");
            }

            for (int isos = 1; isos <= S; isos++)
            {
                for (int x = isos; x >0; x--)
                {
                    triangle += "-";
                }
                triangle += "\n";
            }
            //triangle += "\n";

            for(int i = S - 1; i > 0; i--)
            {
                for(int y = i; y >0; y--)
                {
                    triangle += "-";

                }
                triangle += "\n";
            }
            return triangle;
        }

    }
}