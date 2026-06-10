namespace ClassObjectDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Employee employee = new Employee(1,"Yuvashree",-67990);
            Employee employee2=new Employee(2,"Jey",78000);

            //employee.employeeId = 101;
            //employee.employeeName = "Test Employee";
            //employee.salary = 34566;

            //employee.DisplayEmployee();

            //employee2.employeeId = 102;
            //employee2.employeeName = "Geetha";

            //employee2.DisplayEmployee();

            //Employee employee3=new Employee();
            //employee3.DisplayEmployee();
            //employee.DisplayEmployee();
            //employee2.DisplayEmployee();

            //Employee employee3 = new Employee(employee);
            //employee3.DisplayEmployee();


            EmployeeWithProperties employeeWithProperties1=new EmployeeWithProperties();
            employeeWithProperties1.EmployeeId = 1001;
            employeeWithProperties1.EmployeeName = "Test Employee";
            employeeWithProperties1.Salary = 6789;

            Console.WriteLine("Employee Salary:"+employeeWithProperties1.Salary);
            employeeWithProperties1.DisplayEmployee();
            Console.ReadLine();
        }
    }
}
