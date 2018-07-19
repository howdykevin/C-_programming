using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRRCManagement
//This whole section was done by Kevin Gunawan, n9812482
{
    //defining enum variable Gender
    public enum Gender
    {
        Male,
        Female
    };
    public class Customer
    {
        //defining private variables
        private int customerID;
        private string title;
        private string firstNames;
        private string lastNames;
        private Gender gen;
        private string dateOfBirth;

        //setting the get;set proporties of variables
        public int CustomerID { get => customerID; set => customerID = value; }
        public string Title { get => title; set => title = value; }
        public string FirstNames { get => firstNames; set => firstNames = value; }
        public string LastNames { get => lastNames; set => lastNames = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public Gender Gen { get => gen; set => gen = value; }

        //This is a constructor for customer!
        public Customer(int customerID, string title, string firstNames, string lastName, Gender gender, string dateOfBirth)
        {
            CustomerID = customerID;
            Title = title;
            FirstNames = firstNames;
            LastNames = lastName;
            Gen = gender;
            DateOfBirth = dateOfBirth;
        }
        //This is a method that returns a CSV representation of the customer.
        public string ToCSVString()
        {
            string csvString = "";
            csvString = csvString + CustomerID.ToString() + "," + title + "," + FirstNames + "," + LastNames + "," + Gen.ToString() + "," + DateOfBirth;
            return csvString;

        }



    }
}
