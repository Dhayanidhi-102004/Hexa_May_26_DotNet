using Partial_Sealed_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Sealed_Demo.Services
{
    public sealed  class SalarySlipGenerator
    {
        public string GenerateSalarySlip(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee), "Employee Object cannot be null.");
                }
                if (!employee.IsValidEmployee())
                {
                    throw new InvalidOperationException("Cannot generate salary slip for invalid employee data.");
                }
                decimal monthlySalary = employee.Salary;
                decimal annualSalary = employee.CalculateAnnualSalary();

                decimal providentFund = monthlySalary * 0.12m;
                decimal professionalTax = 200;
                decimal netSalary = monthlySalary - providentFund - professionalTax;

                StringBuilder salarySlip = new StringBuilder();

                salarySlip.AppendLine("-------- SALARY SLIP ------------");
                salarySlip.AppendLine($"Employee Id    :{employee.EmployeeId}");
                salarySlip.AppendLine($"Employee Name    :{employee.EmployeeName}");
                salarySlip.AppendLine($"Department    :{employee.Department}");
                salarySlip.AppendLine($"Joining Date    :{employee.JoiningDate:dd-MM-YYYY}");
                salarySlip.AppendLine($"Experience   :{employee.GetExperienceInYears()}");
                salarySlip.AppendLine("--------------------------------------------");
                salarySlip.AppendLine($"Monthly Salary   :{monthlySalary}");
                salarySlip.AppendLine($"Annual Salary   :{annualSalary}");
                salarySlip.AppendLine($"PF Deduction   :{providentFund}");
                salarySlip.AppendLine($"Professional Tax   :{professionalTax}");
                salarySlip.AppendLine($"Net Salary   :{netSalary}");
                salarySlip.AppendLine("----------------------------------------------------");

                return salarySlip.ToString();
            } catch (ArgumentNullException ex) {
                Console.WriteLine($"Null Error : {ex.Message}");
                return string.Empty;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Business Rule Error :{ex.Message}");
                return string.Empty;
            }
            catch (Exception ex) {
                Console.WriteLine($"Unexpected error while generatingsalsry Slip .. {ex.Message}");
                return string.Empty;
            }
        }
    }
}
