using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectDemo
{
    internal class Employee
    {
        public int employeeId;
        public string employeeName;
        public double salary;




        //default constructor
        public Employee()
        {
            employeeId = 1;
            employeeName = "Geetha";
            salary = 900000;
        }

        //paramterised constructor
        public Employee(int employeeId, string employeeName, double salary)
        {
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.salary = salary;
        }
        //copy cnostructor
        public Employee(Employee emp)
        {
            Console.WriteLine(" Copy Constructor called");
            this.employeeId = emp.employeeId;
            this.employeeName= emp.employeeName;
            this.salary = 98000;
        }
        public void DisplayEmployee()
        {
            Console.WriteLine("Employee Id : "+employeeId);
            Console.WriteLine("Employee Name  :"+employeeName);
            Console.WriteLine("Salary   : "+salary);
        }
    }
}
