// create a 'Die' class, which will allow for the rolling of a single die, which can have a variable number of sides, and the number of sides is passed to the die on construction.
// The 'Die' class should have two private attributes. One which stores the number of faces (numFaces), and one which stores the current face value of the dice (faceValue) - i.e. the face that is currently showing on the dice.
// The 'Die' class must have 2 constructors:
// public Die()
// This constructor creates an instance of Die with the default number of faces, which is 6. The face value should be set to the default face value, which is 1.
// public Die(int faces)
// This constructor creates an instance of Die with a specific number of faces. If 'faces' is less than the minimum number of faces (3), the default number of faces is instantiated (6). The face value should be set to the default face value (1).
// The class must also have three other methods to represent common behaviours of a die.
// public void RollDie()
// This method must roll the die and store the value resulting from the roll internally - i.e. the new face value. Hint - the Random class will be helpful here.
// public int GetFaceValue()
// This method should be used to get the current face value of the die.
// public int GetNumFaces()
// This method should be used to get the number of faces of the die.
// Now, given the defaults, the code Die myDie = new Die(); should create a single six-sided die, with a face value of 1.
// Die myDie = new Die(10);, however, should create a 10-sided Die. Rolling this die should produce values between 1 and 10.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DieRoller
{
    /// <summary>
    /// Represents one die (singular of dice) with faces showing values between
    /// 1 and the number of faces on the die.
    /// </summary>
    public class Die
    {
        // Implement your 'Die' class here
        public Random r = new Random();

        public Die()
        {
            NumFaces = 6;
            FaceValue = 1;
        }

        public Die(int faces)
        {
            FaceValue = 1;
            if (faces < 3)
            {
                NumFaces = 6;
            }
            else
            {
                NumFaces = faces;
            }
        }
        public void RollDie()
        {
        //Random r = new Random(Guid.NewGuid().GetHashCode());
            FaceValue = r.Next(1,NumFaces+1);
        }

        public int GetFaceValue()
        {
            return FaceValue;
        }

        public int GetNumFaces()
        {
            return NumFaces;
        }

        private int numFaces;
        private int faceValue;
        public int NumFaces { get => numFaces; set => numFaces = value; }
        public int FaceValue { get => faceValue; set => faceValue = value; }





    }// end Class Die

    public class Program
    {
        public static void Main()
        {
            // This will not be called by the AMS, however you may want to test your Die class here.
            Die myDie = new Die(10);
            myDie.RollDie();
            Console.WriteLine(myDie.GetFaceValue());
        }
    }
}
