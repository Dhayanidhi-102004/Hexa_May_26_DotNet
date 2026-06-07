using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCourierApp.Models
{
    public class CourierBooking
    {
        public Customer Customer { get; set; } = new();
        public Parcel Parcel { get; set; } = new();
        public string NotificationType { get; set; } = string.Empty;
        public double TotalCharge { get; set; }
    }
}
