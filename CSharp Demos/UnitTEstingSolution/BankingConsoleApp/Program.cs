using BankingConsoleApp.Models;
using BankingConsoleApp.Services;
namespace BankingConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccountService bankAccountService = new BankAccountService();
            BankAccount bankAccount = bankAccountService.CreateAccount(
                1001, "Geetha", 5000);

            Console.WriteLine("Account Created successfully");
            Console.WriteLine("Account Number : "+bankAccount.AccountNumber);
            Console.WriteLine("Account Holder Name : " + bankAccount.AccountHolderName);
            Console.WriteLine("Opening Balance : " + bankAccount.Balance);

            bankAccountService .Deposit(bankAccount,4500);
            Console.WriteLine($"Balance after Deposit : {bankAccount.Balance}");

            bankAccountService.Withdraw(bankAccount,1000);
            Console.WriteLine($"Balance after Withdarw : {bankAccount.Balance}");

            decimal currentBalance = bankAccountService.GetBalance(bankAccount);
            Console.WriteLine("Current Balance : " + currentBalance);

            Console.ReadLine();
        }
    }

   

}
