using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCourierApp.Models;

namespace SmartCourierApp.Notifications
{
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(CourierBooking courierBooking)
        {
            
            Console.WriteLine($"[Email Sent] To: {courierBooking.Customer.CustomerEmail} Message: Dear {courierBooking.Customer.CustomerName}, your courier booking from {courierBooking.Parcel.SourceCity} to {courierBooking.Parcel.DestinationCity} has been successfully confirmed!");
        }
    }
}
