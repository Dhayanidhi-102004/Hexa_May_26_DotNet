using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingConsoleApp.Models
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance  { get; set; }
        public BankAccount(int accountNumber,string accountHolderName,decimal openingBalance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = openingBalance;

        }
    }
}
