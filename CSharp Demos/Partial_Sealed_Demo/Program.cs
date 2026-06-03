using Partial_Sealed_Demo.Models;
using Partial_Sealed_Demo.Services;
namespace Partial_Sealed_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Employee> employees = new List<Employee>
            {
                new Employee{EmployeeId=1,EmployeeName="Janani",Department="IT",Salary=50000,JoiningDate=new DateTime(2025,5,20)},
                 new Employee{EmployeeId=2,EmployeeName="Meenakshi",Department="HR",Salary=45000,JoiningDate=new DateTime(2025,5,25)},
                 new Employee{EmployeeId=3,EmployeeName="Mohamed",Department="Admin",Salary=55000,JoiningDate=new DateTime(2025,5,10)},
            };
                Console.WriteLine("Employee Management System");
                Console.WriteLine("______________________________");

                DisplayEmployees(employees);
                Console.WriteLine("Genrating the Salary Slips...");


                Console.WriteLine();
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "SalarySlips");
                FileService fileService = new FileService(folderPath);
                fileService.CreateFolderIfNotExists();
                SalarySlipGenerator salarySlipGenerator = new SalarySlipGenerator();
                foreach (Employee employee in employees)
                {
                    string salarySlipContent = salarySlipGenerator.GenerateSalarySlip(employee);
                    string safeEmployeeName = employee.EmployeeName.Replace(" ", "");
                    string fileName = $"SalarySlip_{employee.EmployeeId}_{safeEmployeeName}.txt";
                    fileService.WriteToFile(fileName, salarySlipContent);

                    string logContent = $"Salary slip generated for Employee Id : {employee.EmployeeId}, Name: {employee.EmployeeName}";

                    fileService.AppendToFile("SalarySlopLog.txt", logContent);

                }

                Console.WriteLine();
                Console.WriteLine("Reading First Employee Salsry Slip File ...");
                Console.WriteLine();
                string firstEmployeeFileName = "SalarySlip_1_Janani.txt";
                string fileContent = fileService.ReadFromFile(firstEmployeeFileName);
                Console.WriteLine(fileContent);
                Console.ReadLine();
            }catch(Exception ex)
            {
                Console.WriteLine($"Application Error : {ex.Message} ");
            }
            finally
            {
                Console.WriteLine();
                    Console.WriteLine("Application Execution Completed"); ;
            }
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                {
                    Console.WriteLine($"Employee Id     : {employee.EmployeeId}");
                    Console.WriteLine($"Employee Name     : {employee.EmployeeName}");
                    Console.WriteLine($"Department     : {employee.Department}");
                    Console.WriteLine($"Maonthly Salary    : {employee.Salary}");
                    Console.WriteLine($"Annual Salary    : {employee.CalculateAnnualSalary()}");
                    Console.WriteLine($"Joining Date    : {employee.JoiningDate:dd-MM-YYYY}");
                    Console.WriteLine($"Experience    : {employee.EmployeeId}");
                }
            }
        }
    }
}
