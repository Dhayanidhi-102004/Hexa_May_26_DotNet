using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCourierApp.Models;

namespace SmartCourierApp.DeliveryCalculators
{
    public interface IDeliveryChargeCalculator
    {
        double CalculateDeliveryCharge(double weight);
    }
}
