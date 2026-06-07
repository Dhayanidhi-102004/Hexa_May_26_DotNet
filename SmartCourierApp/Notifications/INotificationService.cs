using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCourierApp.Invoices;
using SmartCourierApp.Models;

namespace SmartCourierApp.Notifications
{
    public interface INotificationService
    {
        void SendNotification(CourierBooking courierBooking);
    }
}
