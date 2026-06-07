using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegexDemo
{
    using EmployeeInfo = (int id, string name, double salary);
    internal class CSharp12Features
    {
        public void Demo()
        {

            ////old Method  (Array)
            //int[] numbers = new int[9];

            //int[] numbers2 = [10, 20, 30, 40];

            ////Array in C# 12
            //foreach (var item in numbers2)
            //{
            //    Console.WriteLine(item);
            //}

            ////old method  (Collections)
            //List<string> cities = new List<string>() { "Chennai", "Bangalore", "Hyderabad", "Pune" };


            //List<string> cities1 = ["Chennai", "Bangalore", "Delhi", "Mumbai"];
            //foreach (var item in cities1)
            //{
            //    Console.WriteLine(item);

            //}

            ////Spread Operator
            //int[] first = [1, 2, 3, 4];
            //int[] second = [10, 40, 80, 120];
            //int[] allNumbers = [.. first, .. second, 90, 100];
            //foreach (int item in allNumbers)
            //{
            //    Console.WriteLine(item);

            //}


            ////Example For Lambda with default parameter

            //var greet = (string name="Guest") =>
            //{
            //    Console.WriteLine($"Welcome {name}");
            //};
            //greet();


            //Alias for Tuple

            EmployeeInfo emp = (101, "Geetha", 89000);
            Console.WriteLine($"Id   : {emp.id} \n name    :{emp.name}\n Saalry   : {emp.salary}");



        }
        }
        //    //Primary Constructor
        //    public class Employee
        //    {
        //        private int employeeId;
        //        private string employeeName;
        //        public Employee(int id, string name)
        //        {
        //            employeeId = id;
        //            employeeName = name;
        //        }
        //        public void Display()
        //        {
        //            Console.WriteLine($"Id:{employeeId} - Name : {employeeName}");
        //        }
        //    }


        //    //Primary Constructor
        //    public class Employee1(int id, string name)
        //    {
        //        public void Display()
        //        {
        //            Console.WriteLine($"Id:{id} - Name : {name}");
        //    }



        //Example for Primary Constructor with Property
        public class Employee1(int id, string name)
        {
            public int EmployeeId { get; set ; } = id;
            public string EmployeeName { get; set; } = name;
            public void Display()
            {
                Console.WriteLine($"Id:{EmployeeId} - Name : {EmployeeName}");
            }
        }
    }
    

