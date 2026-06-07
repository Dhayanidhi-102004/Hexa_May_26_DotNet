using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectDemo
{
    internal class EmployeeWithProperties
    {
        public int EmployeeId { get;set;  }
        public string EmployeeName { get;set; }
        private double salary;

        //write only property
        public double Salary
        {
            //get
            //{
            //    return salary;
            //}
            set
            {
                if (value > 0)
                {
                    salary = value;
                }
                else
                {
                    Console.WriteLine("Salary must be greater than 0");
                }
            }
        }
        public void DisplayEmployee()
        {
            Console.WriteLine("Employee Id : " + EmployeeId);
            Console.WriteLine("Employee Name  :" + EmployeeName);
            Console.WriteLine("Salary   : " + Salary);
        }

    }
}
