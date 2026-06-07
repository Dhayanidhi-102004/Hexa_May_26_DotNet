using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace Single_Responsibility_Principle_Demo
{
    /// <summary>
    /// The SRP states that a class should have only one reason to change, meaning it should have only one job or responsibility.
    /// </summary>
    internal class LoanApplication
    {

       public void saveLoanApplication()
        {
            Console.WriteLine("Loan Application Saved.");
        }
        //public void CalculateInterest()
        //{
        //    Console.WriteLine("Interest Calculated");
        //}

        //public void SendEmail()
        //{
        //    Console.WriteLine("Email sent to the Customer");
        //}
    }

    public class InterestCalculator()
    {
        public void CalculateInterest()
        {
            Console.WriteLine("Interest Calculated");
        }
    }

    public class EmailService
    {
        public void SendEmail()
        {
            Console.WriteLine("Email Sent to Customer.");
        }
    }
}
