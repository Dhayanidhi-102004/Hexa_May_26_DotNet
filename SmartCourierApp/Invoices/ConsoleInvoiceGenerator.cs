using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCourierApp.Models;

namespace SmartCourierApp.Invoices
{
    public class ConsoleInvoiceGenerator : IInvoiceGenerator
    {
        public void GenerateInvoice(CourierBooking booking)
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("             COURIER INVOICE              ");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Customer Name    : {booking.Customer.CustomerName}");
            Console.WriteLine($"Source City      : {booking.Parcel.SourceCity}");
            Console.WriteLine($"Destination City : {booking.Parcel.DestinationCity}");
            Console.WriteLine($"Parcel Weight    : {booking.Parcel.Weight} kg");
            Console.WriteLine($"Delivery Type    : {booking.Parcel.DeliveryType}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Total Charge     : {booking.TotalCharge:F2}");
            Console.WriteLine("==========================================\n");
        }
    }
}
