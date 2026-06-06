using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Title { get; set; }= string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location {  get; set; } = string.Empty;
        public string Status {  get; set; } = string.Empty;
        public decimal Fees { get; set; }

    }
}
