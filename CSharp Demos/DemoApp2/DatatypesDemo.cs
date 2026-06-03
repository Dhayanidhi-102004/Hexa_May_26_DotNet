using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp2
{
    internal class DatatypesDemo
    {
      public static void datatypes_demo()
        {
            //Integer Types
            byte employeeAge = 23;
            short employeeCode = 102;
            int employeeId = 1002;
            long aadhaarNumber = 789832435676;

            //Floating type
            float experience = 18.5f;
            double monthlySalary = 45000.6;
            decimal annualPackage = 5400000.90m;


            // char and string
            char gender = 'F';
            string name = "Geetha";
            string city = "Coimbatore";

            //Boolean

            bool isPermenantEmployee = true;
            bool isOnNoticePeriod = false;

            //Date and time
            DateTime joiningDate = new DateTime(2020, 03, 08);

            //Object type
            object department = "IT Department";

            //Dynamic Type
            dynamic bonus = 5000;
            dynamic performanceGrade = "A";

            // Nullable Type
            int? resignationDays = null;

            //Array
            string[] skills = { "C#", "SQL", "ASP.NET CORE", "Azure", "Data Science" };

            Console.WriteLine("Employee PayRoll Details");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Employee Id        :"+employeeId);
            Console.WriteLine("Employee Code        :" + employeeCode); 
            Console.WriteLine("Employee Name      :" + name);
            Console.WriteLine("Age                :" + employeeAge);
            Console.WriteLine("Gender             :" + gender);
            Console.WriteLine("City               :" + city);
            Console.WriteLine("Aadhaar Number     :" + aadhaarNumber);
            Console.WriteLine("Experience         :" + experience);
            Console.WriteLine("Monthly Salary     :" + monthlySalary);
            Console.WriteLine("Annual Package     :" + annualPackage);

            Console.WriteLine("Permanant              :" + isPermenantEmployee);
            Console.WriteLine("Notice Period              :" + isOnNoticePeriod);
            Console.WriteLine("joinng Date              :" + joiningDate);


            Console.WriteLine("Department              :" + department);
            Console.WriteLine("Bonus                  :" + bonus);
            Console.WriteLine("Performance Grade      :" + performanceGrade);
            Console.WriteLine("Resignation Days       :"+resignationDays);

            Console.WriteLine(" Skills ");
            foreach(String skill in skills)
                Console.WriteLine(" - "+ skill);

        }
    }
}
