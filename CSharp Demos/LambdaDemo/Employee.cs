using LambdaDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string Gender { get; set; }
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int Experience { get; set; }
        public bool IsActive { get; set; }
        public void EmployeeDetails()
        {

            List<Employee> employees = new List<Employee>
            {
                new Employee{EmployeeId=101,EmployeeName="Anuj",Gender="Male",Department="IT",Salary=65000,Experience=6,IsActive=true},
                 new Employee{EmployeeId=102,EmployeeName="Banu",Gender="Female",Department="HR",Salary=85000,Experience=8,IsActive=false},
                 new Employee{EmployeeId=103,EmployeeName="Peter",Gender="Male",Department="Sales",Salary=55000,Experience=4,IsActive=true},
                 new Employee{EmployeeId=104,EmployeeName="Sam",Gender="Male",Department="Admin",Salary=165000,Experience=16,IsActive=false},
                 new Employee{EmployeeId=105,EmployeeName="Fransy",Gender="Female",Department="IT",Salary=75000,Experience=7,IsActive=true},
                 new Employee{EmployeeId=106,EmployeeName="Tim",Gender="Male",Department="HR",Salary=65000,Experience=3,IsActive=true},
            };

            var activeEmployee = employees.Where(employee => employee.IsActive == true).ToList();
            Console.WriteLine("1. Active Employees are");
            DisplayEmployees(activeEmployee);

            // IT Employees
            var itEmployees = employees.Where(emp => emp.Department == "IT").ToList();
            Console.WriteLine();
            Console.WriteLine("2. IT Employees");
            DisplayEmployees(itEmployees);


            //Employees with salary greater than 70000
            var highSalaryEmployees = employees.Where(emp => emp.Salary > 70000).ToList();
            Console.WriteLine();
            Console.WriteLine("3. Employees with Salary Greater than 70k");
            DisplayEmployees(highSalaryEmployees);

            // sort Employees by salary ascending
            var employeeBySalary = employees.OrderBy(emp => emp.Salary).ToList();
            Console.WriteLine();
            Console.WriteLine("4. sort Employees by salary ascending");
            DisplayEmployees(employeeBySalary);

            // sort Employees by salary descending
            var employeeBySalaryDescending = employees.OrderByDescending(emp => emp.Salary).ToList();
            Console.WriteLine();
            Console.WriteLine("5. sort Employees by salary descending");
            DisplayEmployees(employeeBySalaryDescending);

            //select only Employee names
            var employeeNames = employees.Select(emp => emp.EmployeeName).ToList();
            Console.WriteLine();
            Console.WriteLine("6. Employee Names");
            foreach (var name in employeeNames)
            { Console.WriteLine(name); }

            // find Employee based on id
            var selectedEmployee = employees.FirstOrDefault(emp => emp.EmployeeId == 3);
            Console.WriteLine();
            Console.WriteLine("7. Find Employee By id");
            if (selectedEmployee != null)
            {
                Console.WriteLine($"Employee Found :{selectedEmployee.EmployeeName}");
            }
            else
            {
                Console.WriteLine("Emplyee Not Found");
            }

            // Group emplyees by Department

            var employeesGroupedByDepartment = employees.GroupBy(emp => emp.Department);
            Console.WriteLine();
            Console.WriteLine("8. Emplyee sGrouped by Department");
            foreach (var departmentGroup in employeesGroupedByDepartment)
            {
                Console.WriteLine($"Department: {departmentGroup.Key}");

                foreach (var employee in departmentGroup)
                {
                    Console.WriteLine($"  {employee.EmployeeName} - {employee.Salary}");
                }
            }

            // Count Employees in each department
            var departmentCount = employees.GroupBy(emp => emp.Department)
                                .Select(group => new
                                {
                                    Department = group.Key,
                                    EmployeeCount = group.Count()
                                });

            Console.WriteLine();
            Console.WriteLine($"9. DEpartment wise Employee Count");
            foreach (var item in departmentCount)
            {
                Console.WriteLine($"{item.Department}:  {item.EmployeeCount}");
            }
        }

        static void DisplayEmployees(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(
                    $"Id              :{employee.EmployeeId}, " +
                    $"Name            : {employee.EmployeeName}, " +
                    $"Department      : {employee.Department},  " +
                    $"Salary          :{employee.Salary} ," +
                    $"Experience      :{employee.Experience}, " +
                    $"Active          :{employee.IsActive}");
            }
        }
    }
}
