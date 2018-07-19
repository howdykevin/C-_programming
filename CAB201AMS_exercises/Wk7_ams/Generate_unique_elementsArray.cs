// write a method called InitializeArrayWithNoDuplicates(), using the provided method header below, which will return a one dimensional array in which every element is a randomly generated integer between 1 and 45 inclusive with no integer value occurring more than once in the array.
// The length of the array is passed as a parameter to the method and you can assume that the parameter value will be less than 45 and greater than zero.
// Use the Random class method int Next(int minValue, int maxValue) which returns a random integer which is greater than or equal to minValue and less than maxValue.



using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RandomArray
{
    public class RandomArrayNoDuplicates
    {
        static Random rng = new Random();
        /// <summary>
        /// Creates an array with each element a unique integer
        /// between 1 and 45 inclusively.
        /// </summary>
        /// <param name="size"> length of the returned array < 45
        /// </param>
        /// <returns>an array of length "size" and each element is
        /// a unique integer between 1 and 45 inclusive </returns>
        /// 
        private static int minimum = 1;
        private static int maximum = 45;
        static int[] newArray;

        //public int Minimum { get => minimum; set => minimum = value; }
        //public int Maximum { get => maximum; set => maximum = value; }

        public static int[] InitializeArrayWithNoDuplicates(int size)
        {
            newArray = new int[size];
            //a clean way to check whether there are any duplicates in the elements in an array
            for (int i = 0; i < size; i++)
            {
                bool cont = false;
                do
                {
                    //put cont=false here so that the once it loops back up again, cont will become false. there wont be infinite loops
                    cont = false;
                    int randomNum = rng.Next(minimum, maximum + 1);
                    newArray[i] = randomNum;
                    // checking of the next element to the ones before it. When i=0, this for loop will not run as j=0 and j<0 so the loop does not run
                    for (int j = 0; j < i; j++)
                    {
                        if (newArray[j] == randomNum)
                        {
                            cont = true;
                        }
                    }

                } while (cont);


            }
            return newArray;
        }

        public static void DisplayArray(int[] newArray)
        {
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.WriteLine(newArray[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //RandomArrayNoDuplicates newRandom = new RandomArrayNoDuplicates();
            int[] array = RandomArrayNoDuplicates.InitializeArrayWithNoDuplicates(5);
            RandomArrayNoDuplicates.DisplayArray(array);
            Console.WriteLine("\n");
            int[] array1 = RandomArrayNoDuplicates.InitializeArrayWithNoDuplicates(6);
            RandomArrayNoDuplicates.DisplayArray(array1);
            Console.WriteLine("\n");
            int[] array2 = RandomArrayNoDuplicates.InitializeArrayWithNoDuplicates(8);
            RandomArrayNoDuplicates.DisplayArray(array2);
            Console.WriteLine("\n");

        }
    }
}