using BankingConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp.Services
{
    public class BankAccountService
    {
        public BankAccount CreateAccount(int accountNumber, string accountHolderName, decimal openingBalance)
        {
            if (accountNumber <= 0)
            {
                throw new ArgumentException("Account Number must be greater tahn zero.");
            }
            if (string.IsNullOrWhiteSpace(accountHolderName))
            {
                throw new ArgumentException("Account holder name is required");
            }
            if (openingBalance <= 0)
            {
                throw new ArgumentException("Opening Balance caanot be negative.");
            }
            return new BankAccount(accountNumber, accountHolderName, openingBalance);
        }

        public void Deposit(BankAccount account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            account.Balance += amount;
        }


        public void Withdraw(BankAccount account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Withdraw amount must be greater than zero.");
            }
            if (amount > account.Balance)
            {
                throw new InvalidOperationException("Insufficient Balance.");
            }
            account.Balance -= amount;
        }
        public decimal GetBalance(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account cannot be null");
            }
            return account.Balance;
        }
    }
}
