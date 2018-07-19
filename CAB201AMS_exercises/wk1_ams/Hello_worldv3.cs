// take the "Hello World" program and further extend it to ask for the user's height (in centimetres). It should then remark, if the number entered is greater than 180cm, 
// that the user is taller than most people, or shorter otherwise.

using System;

public class FirstProgramV3
{
    public static void Main()
    {
        // Declare a 'string' variable called 'name' to hold the user's name
        string name;

        // Declare an 'int' variable called 'height' to hold the user's height
        int height;

        // Display the message "Please enter your name:  ".
        // (hint: Use Console.Write instead of WriteLine for this)
        Console.Write("Please enter your name:  ");

        // Use Console.ReadLine to read what the user types into the 'name' variable
        name=Console.ReadLine();

        // Write a single blank line
        Console.WriteLine();

        // Write "Hello (name goes here), and welcome to CAB201" on a line by itself.
        // Instead of (name goes here) you should put in the name the user gave you.
        Console.WriteLine("Hello " + name + ", and welcome to CAB201");

        // Write "How tall are you, (name goes here)?  "
        // (use Console.Write instead of Console.WriteLine for this)
        Console.Write("How tall are you, " + name + "?  ");

        // Read in the user's height (in centimeters)
        height = int.Parse(Console.ReadLine());

        // If the user's height is greater than 180cm, display this message:
        // "(name goes here), you are taller than most people!"
        // Otherwise, display this message:
        // "(name goes here), you are shorter than most people!"
        if(height>=180)
        {
            Console.WriteLine(name + ", you are taller than most people!");
        } else
        {
            Console.WriteLine(name + ", you are shorter than most people!");
        }

        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }
}