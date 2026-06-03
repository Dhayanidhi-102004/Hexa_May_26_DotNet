using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariance_ContraVariance_Demo
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
    }

    public class CreditCardPayment:Payment
    {
        public string CardNumber { get; set; }
    }
   public  class UpiPayment:Payment
    {
        public string UpiId { get; set; }
    }
}
