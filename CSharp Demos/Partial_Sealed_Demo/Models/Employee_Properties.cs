using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partial_Sealed_Demo.Models
{
    internal class Employee_Properties
    {
    }

    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;
        public decimal  Salary { get; set; }

        public DateTime JoiningDate { get; set; }
    }

}
