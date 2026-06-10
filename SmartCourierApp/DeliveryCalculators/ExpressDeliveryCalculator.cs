using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCourierApp.Models;

namespace SmartCourierApp.DeliveryCalculators
{
    public class ExpressDeliveryCalculator : IDeliveryChargeCalculator
    {
        public double CalculateDeliveryCharge(double weight) => weight * 80 + 100;
    }
}
