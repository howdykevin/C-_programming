// create a BankAccount class. This class will need to keep track of an account balance and interest rate, and provide methods for manipulating these fields and calculating interest.
// The BankAccount class will be used as an object, and as such will need to have non-static fields and methods. The account balance and interest rate will need to be private variables that can only be accessed or modified through public methods.
// Here are a list of methods that you need to implement for BankAccount. A class structure has been provided for you- you will just need to write code where the comments tell you to.
// BankAccount()
// The default constructor. This creates a new account with a balance of $0 and an interest rate of 9.6%.
// BankAccount(startingBalance)
// This constructor creates a new account with a balance of startingBalance and an interest rate of 9.6%.
// BankAccount(startingBalance, interestRate)
// This constructor creates a new account with a balance of $startingBalance and an interest rate of interestRate%.
// Withdraw(amount)
// If there is enough money in the account, this method subtracts amount from the current balance and returns true. If there isn't enough, this method leaves the balance untouched and instead returns false.
// Deposit(amount)
// This method adds amount to the current balance.
// QueryBalance()
// This method returns the current balance of the account.
// SetInterestRate(interestRate)
// This method sets the interest rate of the account to interestRate%.
// GetInterestRate()
// This method returns the current interest rate of the account. If the interest rate is 9.6% this method should return 9.6.
// AddInterest()
// This method calculates interest based on the current balance and adds it to the balance. If the balance is $100 and the interest rate 5% when this method is called, the new balance of the account should be $105 (5% of $100 is $5).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankAccount
    {
        // Private variables for storing the account balance and interest rate
        // ...
        private double accountBalance;
        private double interestRate;

        public double AccountBalance { get => accountBalance; set => accountBalance = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }

        /// <summary>
        /// Creates a new bank account with no starting balance and the default
        /// interest rate.
        /// </summary>
        public BankAccount()
        {
            // ...
            AccountBalance = 0;
            InterestRate = 9.6;
        }

        /// <summary>
        /// Creates a new bank account with a starting balance and the default
        /// interest rate.
        /// </summary>
        /// <param name="startingBalance">The starting balance</param>
        public BankAccount(double startingBalance)
        {
            // ...
            AccountBalance = startingBalance;
            InterestRate = 9.6;

        }

        /// <summary>
        /// Creates a new bank account with a starting balance and interest
        /// rate.
        /// </summary>
        /// <param name="startingBalance">The starting balance</param>
        /// <param name="interestRate">The interest rate (in percentage)</param>
        public BankAccount(double startingBalance, double interestRate)
        {
            // ...
            AccountBalance = startingBalance;
            InterestRate = interestRate;
        }

        /// <summary>
        /// Reduce the balance of the bank account by 'amount' and return true.
        /// If there are insufficient funds in the account, the balance does not
        /// change and false is returned instead. 
        /// </summary>
        /// <param name="amount">The amount of money to deduct from the account
        /// </param>
        /// <returns>True if funds were deducted from the account, and false
        /// otherwise</returns>
        public bool Withdraw(double amount)
        {
            // ...
            if(AccountBalance-amount < 0)
            {
                return false;
            }
            else
            {
                AccountBalance -= amount;
                return true;
            }
        }

        /// <summary>
        /// Increase the balance of the account by 'amount'
        /// </summary>
        /// <param name="amount">The amount to increase the balance by</param>
        public void Deposit(double amount)
        {
            // ...
            AccountBalance += amount;
        }

        /// <summary>
        /// Returns the total balance currently in the account.
        /// </summary>
        /// <returns>The total balance currently in the account</returns>
        public double QueryBalance()
        {
            // ...
            return AccountBalance;
        }

        /// <summary>
        /// Sets the account's interest rate to the rate provided
        /// </summary>
        /// <param name="interestRate">The interest rate for this account (%)
        /// </param>
        public void SetInterestRate(double interestRate)
        {
            // ...
            InterestRate = interestRate;
        }

        /// <summary>
        /// Returns the account's interest rate
        /// </summary>
        /// <returns>The percentage interest rate of this account</returns>
        public double GetInterestRate()
        {
            // ...
            return InterestRate;
        }

        /// <summary>
        /// Calculates the interest on the current account balance and adds it
        /// to the account
        /// </summary>
        public void AddInterest()
        {
            // ...
            double interestAmount;
            interestAmount = AccountBalance * (InterestRate / 100.0);
            AccountBalance += interestAmount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount(0, 5);
            myAccount.Deposit(1000);
            myAccount.AddInterest();
            Console.WriteLine("My current bank balance is $ {0:0.00}\n",
              myAccount.QueryBalance());

            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}

