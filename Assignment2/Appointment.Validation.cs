using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public partial class Appointment
    {
        public void validateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) Console.WriteLine("Enter a valid title");
        }
        public bool validateTime(DateTime time)
        {
            Func<DateTime, bool> checkHours = t => t.Hour >= 9 && t.Hour < 17;
            return checkHours(time);
        }
    }
}
