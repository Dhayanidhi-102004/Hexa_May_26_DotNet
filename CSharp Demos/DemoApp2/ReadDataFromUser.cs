using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp2
{
    internal class ReadDataFromUser
    {
        public void GetDifferentEmployeeDetails()
        {

            //Integer Types
            Console.WriteLine("Enter Employee Age");
            byte employeeAge = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter Employss Code");
            short employeeCode = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter Employee ID: ");
            int employeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Aadhaar Number: ");
            long aadhaarNumber = Convert.ToInt64(Console.ReadLine());

            // Taking floating point input
            Console.Write("Enter Experience in years: ");
            float experience = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter Monthly Salary: ");
            double monthlySalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Annual Package: ");
            decimal annualPackage = Convert.ToDecimal(Console.ReadLine());



            // char and string
            Console.Write("Enter Gender M/F: ");
            char gender = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            string employeeName = Console.ReadLine();

            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            //Boolean

            Console.Write("Is Permanent Employee? true/false: ");
            bool isPermanentEmployee = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Is On Notice Period? true/false: ");
            bool isOnNoticePeriod = Convert.ToBoolean(Console.ReadLine());

            //Date and time
            Console.Write("Enter Joining Date yyyy-mm-dd: ");
            DateTime joiningDate = Convert.ToDateTime(Console.ReadLine());


            //Object type
            Console.Write("Enter Department: ");
            object department = Console.ReadLine();

            //Dynamic Type
            Console.Write("Enter Bonus Amount: ");
            dynamic bonus = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Performance Grade: ");
            dynamic performanceGrade = Console.ReadLine();


            // Nullable Type
            Console.Write("Enter Resignation Days, or press Enter if not applicable: ");
            string resignationInput = Console.ReadLine();

            int? resignationDays;

            if (string.IsNullOrEmpty(resignationInput))
            {
                resignationDays = null;
            }
            else
            {
                resignationDays = Convert.ToInt32(resignationInput);
            }


            //Array
            Console.Write("How many skills do you want to enter? ");
            int skillCount = Convert.ToInt32(Console.ReadLine());

            string[] skills = new string[skillCount];

            for (int i = 0; i < skillCount; i++)
            {
                Console.Write("Enter Skill " + (i + 1) + ": ");
                skills[i] = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("Employee Payroll Details");
            Console.WriteLine("------------------------");

            Console.WriteLine("Employee ID       : " + employeeId);
            Console.WriteLine("Employee Code     : " + employeeCode);
            Console.WriteLine("Employee Name     : " + employeeName);
            Console.WriteLine("Age               : " + employeeAge);
            Console.WriteLine("Gender            : " + gender);
            Console.WriteLine("City              : " + city);

            Console.WriteLine("Aadhaar Number    : " + aadhaarNumber);
            Console.WriteLine("Experience        : " + experience + " years");
            Console.WriteLine("Monthly Salary    : " + monthlySalary);
            Console.WriteLine("Annual Package    : " + annualPackage);

            Console.WriteLine("Permanent         : " + isPermanentEmployee);
            Console.WriteLine("Notice Period     : " + isOnNoticePeriod);
            Console.WriteLine("Joining Date      : " + joiningDate.ToShortDateString());

            Console.WriteLine("Department        : " + department);
            Console.WriteLine("Bonus             : " + bonus);
            Console.WriteLine("Performance Grade : " + performanceGrade);

            Console.WriteLine("Resignation Days  : " + resignationDays);

            Console.WriteLine("Skills:");
            foreach (string skill in skills)
            {
                Console.WriteLine("- " + skill);
            }
        }
    }
}
