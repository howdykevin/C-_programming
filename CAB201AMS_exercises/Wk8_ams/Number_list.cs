 // create a NumberList class. This class will need to keep track of a list of any number of floating-point values and be able to perform operations on these values


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//removing/adding/using methods of list class.Impt notes in line 58 to 59 with 
//regards to looping through list with foreach and removing items
namespace Numbers
{
    public class NumberList
    {
        // Your private List<float> field should go here
        // ...
        List<float> Number = new List<float>();

        public void Add(float number)
        {
            // ...
            Number.Add(number);
        }

        public List<float> Numbers()
        {
            return Number;
        }

        public float Minimum()
        {
            float minimum= Number.Min();
            return minimum;
        }
        public float Maximum()
        {
            // ...
            float max = Number.Max();
            return max;
        }
        public float Sum()
        {
            // ...
            float total = Number.Sum();
            return total;
        }
        public float Average()
        {
            // ...
            float average = Number.Average();
            return average;
        }
        public int Count()
        {
            // ...
            int no = Number.Count;
            return no;
        }
        public void DeleteBelow(float threshold)
        {
            // ...
            //it is not possible to remove items in collection while in foreach loop. 
            //To remove items in list in foreach loop, use the Tolist() to make a copy of the reference of list.
            foreach (float item in Number.ToList())
            {
                if (item < threshold)
                {
                    Number.Remove(item);
                }
            }
            
        }
        public void DeleteAbove(float threshold)
        {
            // ...
            foreach(float item in Number.ToList())
            {
                if(item > threshold)
                {
                    Number.Remove(item);
                }
            }
        }
        public int CountBelow(float threshold)
        {
            // ...
            int total = Number.Count();
            foreach (float item in Number.ToList())
            {
                if (item>threshold)
                {
                    total -= 1;
                }
            }
            return total;
        }
        public int CountAbove(float threshold)
        {
            // ...
            int total = Number.Count();
            foreach (var item in Number.ToList())
            {
                if (item < threshold)
                {
                    total -= 1;
                }
            }
            return total;
        }
    }
    public class Program
    {
        private static string ListToString(List<float> numbers)
        {
            string text = "";
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i > 0) text += ", ";
                text += String.Format("{0}", numbers[i]);
            }
            text += "";
            return text;
        }
        static void Main(string[] args)
        {
            NumberList myList = new NumberList();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            Console.WriteLine("{0} should be 1", myList.Minimum());
            Console.WriteLine("{0} should be 5", myList.Maximum());
            Console.WriteLine("{0} should be 15", myList.Sum());
            Console.WriteLine("{0} should be 3", myList.Average());
            Console.WriteLine("{0} should be 5", myList.Count());
            Console.WriteLine("{0} should be 2", myList.CountBelow(2.5f));
            Console.WriteLine("{0} should be 2", myList.CountAbove(3.5f));

            Console.WriteLine("{0} should be 1, 2, 3, 4, 5", ListToString(myList.Numbers()));
            myList.DeleteBelow(2.5f);
            Console.WriteLine("{0} should be 3, 4, 5", ListToString(myList.Numbers()));

            myList.Add(6);
            myList.Add(7);

            myList.DeleteAbove(4.5f);
            Console.WriteLine("{0} should be 3, 4", ListToString(myList.Numbers()));

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}
