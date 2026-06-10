using Partial_Sealed_Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Sealed_Demo.Models
{
    internal class Employee_Validation
    {
    }

    public partial class Employee
    {
        public bool IsValidEmployee()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(EmployeeName))
                {
                    Console.WriteLine("Validation Error: Employee name is required.");
                    return false;
                }
                if (string.IsNullOrWhiteSpace(Department))
                {
                    Console.WriteLine("Validation Error. Department is required.");
                    return false;
                }
                if (Salary <= 0)
                {
                    Console.WriteLine("Validation Error: Salary must be greater than 0");
                    return false;
                }
                if (JoiningDate > DateTime.Now)
                {
                    Console.WriteLine("Validation Error: Joining Date cannot be a future date.");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UnExpected Validation Error  :{ex.Message}");
                return false;
            }
        }
    }
}
