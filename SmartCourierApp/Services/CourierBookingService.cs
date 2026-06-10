using System;
using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Invoices;
using SmartCourierApp.Models;
using SmartCourierApp.Notifications;

namespace SmartCourierApp.Services
{
    public class CourierBookingService
    {
        private readonly IDeliveryChargeCalculator _calculator;
        private readonly INotificationService _notificationService;
        private readonly IInvoiceGenerator _invoiceGenerator;

        public CourierBookingService(
            IDeliveryChargeCalculator calculator,
            INotificationService notificationService,
            IInvoiceGenerator invoiceGenerator)
        {
            _calculator = calculator;
            _notificationService = notificationService;
            _invoiceGenerator = invoiceGenerator;
        }

        public void ProcessBooking(CourierBooking booking)
        {
            booking.TotalCharge = _calculator.CalculateDeliveryCharge(booking.Parcel.Weight);

            _invoiceGenerator.GenerateInvoice(booking);

            _notificationService.SendNotification(booking);
        }
    }
}