using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCourierApp.Models;

namespace SmartCourierApp.Notifications
{
    public class WhatsAppNotificationService : INotificationService
    {
        public void SendNotification(CourierBooking booking)
        {
            Console.WriteLine($"[WhatsApp Sent] To: {booking.Customer.CustomerPhone} | Message: Courier Booking Confirmed! Weight: {booking.Parcel.Weight}kg. Thank you for choosing SmartCourier!");
        }
    }
}
