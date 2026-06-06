using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceConsoleApp.Services
{
    public class OrderBillingService
    {
        public decimal CalculateSubTotal(decimal price, int quantity)
        {
            if(price <= 0) throw new ArgumentException("Price must be non-negative.");
            if(quantity <= 0) throw new ArgumentException("Quantity must be non-negative.");
            return price * quantity;
        }
        public decimal CalculateDiscount(decimal subTotal)
        {
            decimal discountPercentage=0;
            if (subTotal >= 5000) discountPercentage = 10;
            else if (subTotal >= 2000) discountPercentage = 5;
            return subTotal * (discountPercentage / 100);
        }
        public decimal CalculateDeliveryCharge(decimal amountAfterDiscount)
        {
            if (amountAfterDiscount >= 1000) return 0;
            else return 100;
        }
        public decimal CalculateFinalAmount(decimal price,int quantity)
        {
            decimal subtotal=CalculateSubTotal(price, quantity);
            decimal discount=CalculateDiscount(subtotal);
            decimal amountAfterDiscount=subtotal-discount;
            decimal deliveryCharge=CalculateDeliveryCharge(amountAfterDiscount);
            return amountAfterDiscount + deliveryCharge;
        }
    }
}
