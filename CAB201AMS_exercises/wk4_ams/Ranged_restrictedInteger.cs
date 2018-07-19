// create a RangedInteger class. This class will need to keep track of a single value and ensure that it remains between a provided minimum or maximum, 
// which are specified in RangedInteger's constructor. If the value is set to something outside those values it should be set to the minimum or maximum value, whichever is closer.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeRestrictedInteger
{
    public class RangedInteger
    {
        // Add private variables here, as necessary
        // ...
        private int minimum;
        private int maximum;
        private int _value;


        public RangedInteger(int min, int max)
        {
            // ...
            minimum = min;
            maximum = max;
        }

        public int Value
        {
            get
            {
                // ...
                return _value;
                
            }
            set
            {
                // ...
                if (value < minimum)
                {
                    value = minimum;
                }
                else if (value > maximum)
                {
                    value = maximum;
                }
                _value = value;
            }
        }

        //public int Min { get => min; set => min = value; }
        //public int Max { get => max; set => max = value; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RangedInteger myInteger = new RangedInteger(0, 100);
            myInteger.Value = 57;
            Console.WriteLine("{0}", myInteger.Value); // Should be 57
            myInteger.Value = 103;
            Console.WriteLine("{0}", myInteger.Value); // Should be 100
            myInteger.Value = -4;
            Console.WriteLine("{0}", myInteger.Value); // Should be 0

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}
