using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Sealed_Demo.Models
{
    internal class Employee_Business
    {
    }
    public partial class Employee
    {
        public decimal CalculateAnnualSalary()
        {
            try
            {
                if (Salary <= 0)
                {
                    throw new InvalidOperationException("Salary must be greater than 0 to calculate Annual Salary");
                }
                return Salary * 12;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error While Calculating annual Salary: {ex.Message}");
                return 0;
            }
        }

        public int GetExperienceInYears()
        {
            try
            {
                if (JoiningDate == default)
                {
                    throw new InvalidOperationException("Joining Date is not Set.");
                }
                if (JoiningDate > DateTime.Today)
                {
                    throw new InvalidOperationException("Joining Date cannot be future date.");
                }

                DateTime today = DateTime.Today;
                int years = today.Year - JoiningDate.Year;
                if (JoiningDate.Date > today.AddYears(-years))
                {
                    years--;
                }
                return years;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while calculating the Experience: {ex.Message}");
                return 0;
            }
        }
    }
}
