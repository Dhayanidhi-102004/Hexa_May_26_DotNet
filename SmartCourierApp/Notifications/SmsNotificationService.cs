using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCourierApp.Models;

namespace SmartCourierApp.Notifications
{
    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(CourierBooking booking)
        {
            Console.WriteLine($"[SMS Sent] To: {booking.Customer.CustomerPhone} | Message: Booking confirmed for {booking.Customer.CustomerName}. Charge: {booking.TotalCharge:C}");
        }
    }
}
