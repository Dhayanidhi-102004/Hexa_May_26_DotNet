using System;
using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Invoices;
using SmartCourierApp.Models;
using SmartCourierApp.Notifications;
using SmartCourierApp.Services;

namespace SmartCourierApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SmartCourier Delivery Management System ---\n");

            CourierBooking booking = CollectBookingDetails();

            IDeliveryChargeCalculator? calculator = GetDeliveryCalculator(booking.Parcel.DeliveryType);
            INotificationService? notificationService = GetNotificationService(booking.NotificationType);
            IInvoiceGenerator invoiceGenerator = new ConsoleInvoiceGenerator();

            if (calculator == null || notificationService == null)
            {
                Console.WriteLine("\nInvalid calculation configuration or notification channel selected. Booking aborted.");
                return;
            }

            CourierBookingService bookingService = new CourierBookingService(calculator, notificationService, invoiceGenerator);
            bookingService.ProcessBooking(booking);

            Console.WriteLine("\nBooking complete! Press any key to exit.");
            Console.ReadKey();
        }

        private static CourierBooking CollectBookingDetails()
        {
            var booking = new CourierBooking();

            Console.Write("Enter Customer Name: ");
            booking.Customer.CustomerName = Console.ReadLine() ?? "";

            Console.Write("Enter Customer Email: ");
            booking.Customer.CustomerEmail = Console.ReadLine() ?? "";

            Console.Write("Enter Customer Mobile Number: ");
            booking.Customer.CustomerPhone = Console.ReadLine() ?? "";

            Console.Write("Enter Parcel Weight (in kg): ");
            double.TryParse(Console.ReadLine(), out double weight);
            booking.Parcel.Weight = weight;

            Console.Write("Enter Source City: ");
            booking.Parcel.SourceCity = Console.ReadLine() ?? "";

            Console.Write("Enter Destination City: ");
            booking.Parcel.DestinationCity = Console.ReadLine() ?? "";

            Console.WriteLine("\nSelect Delivery Type:");
            Console.WriteLine("1. Standard Delivery");
            Console.WriteLine("2. Express Delivery");
            Console.WriteLine("3. International Delivery");
            Console.Write("Choice (1-3): ");
            booking.Parcel.DeliveryType = Console.ReadLine() ?? "";

            Console.WriteLine("\nSelect Notification Type:");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. SMS");
            Console.WriteLine("3. WhatsApp");
            Console.Write("Choice (1-3): ");
            booking.NotificationType = Console.ReadLine() ?? "";

            return booking;
        }

        private static IDeliveryChargeCalculator? GetDeliveryCalculator(string choice)
        {
            return choice switch
            {
                "1" => new StandardDeliveryCalculator(),
                "2" => new ExpressDeliveryCalculator(),
                "3" => new InternationalDeliveryCalculator(),
                _ => null
            };
        }

        private static INotificationService? GetNotificationService(string choice)
        {
            return choice switch
            {
                "1" => new EmailNotificationService(),
                "2" => new SmsNotificationService(),
                "3" => new WhatsAppNotificationService(),
                _ => null
            };
        }
    }
}