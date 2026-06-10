using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCourierApp.DeliveryCalculators
{
    public class StandardDeliveryCalculator : IDeliveryChargeCalculator
    {
        public double CalculateDeliveryCharge(double weight) => weight * 10;
    }
}
