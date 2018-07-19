// For this exercise you are to take the "Hello World" program and extend it to take user input. The program should display "Please enter your name: " and wait for you to type something.

// After typing your name and pressing enter, the program should display "Hello (name goes here), and welcome to CAB201" but with the name you entered in the place of (name goes here).

// Finally, the program should display "Press enter to exit" and then wait for the user to press enter before closing.


using System;

public class FirstProgramV2
{
    public static void Main()
    {
        // Declare a 'string' variable called 'name' to hold the user's name
        string name;

        // Display the message "Please enter your name:  ".
        // (hint: Use Console.Write instead of WriteLine for this)
        Console.Write("Please enter your name: ");


        // Use Console.ReadLine to read what the user types into the 'name' variable
        name = Console.ReadLine();

        // Write a single blank line
        Console.WriteLine( );

        // Write "Hello (name goes here), and welcome to CAB201" on a line by itself.
        // Instead of (name goes here) you should put in the name the user gave you.
        Console.Write("Hello "+name+", and welcome to CAB201");

        // Write "Press enter to exit" on a line by itself
        Console.Write("Press enter to exit");

        // Wait for the user to press the enter key
        Console.ReadLine();
    }
}