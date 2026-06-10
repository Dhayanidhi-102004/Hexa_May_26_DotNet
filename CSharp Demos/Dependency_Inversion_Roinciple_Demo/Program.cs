using static Dependency_Inversion_Roinciple_Demo.EmployeeDataAccessLogic;

namespace Dependency_Inversion_Roinciple_Demo
{
    /// <summary>
    /// The Dependency Inversion Principle (DIP) states that High-Level Modules/Classes should not 
    /// depend on Low-Level Modules/Classes. Both should depend upon Abstractions (e.g., interfaces or abstract classes). 
    /// Secondly, Abstractions should not depend upon Details. But Details should depend upon Abstractions.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeBusinessLogic employeeBusinessLogic = new EmployeeBusinessLogic();
            Employee emp = employeeBusinessLogic.GetEmployeeDetails(1001);
            Console.WriteLine($"Id:{emp.ID} , Name : {emp.Name}, department : {emp.Department}, Salary ; {emp.Salary}");

            Console.ReadLine();
        }
    }
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
    }

    //public class EmployeeDataAccessLogic
    //{
    //    public Employee GetEmployeeDetails(int id)
    //    {
    //        //In real time get the employee details from database
    //        //but here we have hard coded the employee details
    //        Employee emp = new Employee()
    //        {
    //            ID = id,
    //            Name = "Test employee",
    //            Department = "IT",
    //            Salary = 10000
    //        };
    //        return emp;
    //    }
    //    public class DataAccessFactory
    //    {
    //        public static EmployeeDataAccessLogic GetEmployeeDataAccessObj()
    //        {
    //            return new EmployeeDataAccessLogic();
    //        }
    //    }
    //    }
    //public class EmployeeBusinessLogic
    //{
    //    EmployeeDataAccessLogic _EmployeeDataAccessLogic;
    //    public EmployeeBusinessLogic()
    //    {
    //        _EmployeeDataAccessLogic = DataAccessFactory.GetEmployeeDataAccessObj();
    //    }
    //    public Employee GetEmployeeDetails(int id)
    //    {
    //        return _EmployeeDataAccessLogic.GetEmployeeDetails(id);
    //    }
    //}

    public interface IEmployeeDataAccessLogic
    {
        Employee GetEmployeeDetails(int id);
    }

    public class EmployeeDataAccessLogic : IEmployeeDataAccessLogic
    {
        public Employee GetEmployeeDetails(int id)
        {
            //In real time get the employee details from database
            //but here we have hard coded the employee details
            Employee emp = new Employee()
            {
                ID = id,
                Name = "Test employee",
                Department = "IT",
                Salary = 10000
            };
            return emp;
        }

    }

    public class DataAccessFactory
    {
        public static IEmployeeDataAccessLogic GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccessLogic();
        }
    }

    public class EmployeeBusinessLogic
    {
        IEmployeeDataAccessLogic _IEmployeeDataAccessLogic;
        public EmployeeBusinessLogic()
        {
            _IEmployeeDataAccessLogic = DataAccessFactory.GetEmployeeDataAccessObj();
        }
        public Employee GetEmployeeDetails(int id)
        {
            return _IEmployeeDataAccessLogic.GetEmployeeDetails(id);
        }
    }
}

