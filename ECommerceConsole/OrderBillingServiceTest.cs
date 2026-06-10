using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using ECommerceConsoleApp.Services;

namespace ECommerceConsole
{
    [TestFixture]
    public class OrderBillingServiceTest
    {
        private OrderBillingService _orderBillingService;
        [SetUp]
        public void Setup()
        {
            _orderBillingService = new OrderBillingService();
        }
        [TestCase(0, 5)]
        [TestCase(5, 0)]
        [TestCase(-1, 5)]
        public void calculateSubTotal_InValidInput(decimal price, int quantity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => _orderBillingService.CalculateSubTotal(price, quantity));
            Assert.That(ex.Message, Is.EqualTo("Price must be non-negative.").Or.EqualTo("Quantity must be non-negative."));
        }
        [TestCase(1, 1)]
        [TestCase(5, 5)]
        public void calculateSubTotal_ValidInput(decimal price, int quantity)
        {
            decimal expected = price * quantity;
            decimal actual = _orderBillingService.CalculateSubTotal(price, quantity);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void calculateDiscount_Test()
        {
            decimal subTotal1 = 6000;
            decimal expectedDiscount1 = 6000 * 0.10m;
            decimal actualDiscount1 = _orderBillingService.CalculateDiscount(subTotal1);
            Assert.That(actualDiscount1, Is.EqualTo(expectedDiscount1));
            decimal subTotal2 = 3000;
            decimal expectedDiscount2 = 3000 * 0.05m;
            decimal actualDiscount2 = _orderBillingService.CalculateDiscount(subTotal2);
            Assert.That(actualDiscount2, Is.EqualTo(expectedDiscount2));
            decimal subTotal3 = 1000;
            decimal expectedDiscount3 = 0;
            decimal actualDiscount3 = _orderBillingService.CalculateDiscount(subTotal3);
            Assert.That(actualDiscount3, Is.EqualTo(expectedDiscount3));
        }
        [Test]
        public void calculateDeliveryCharge_Test()
        {
            decimal amountAfterDiscount1 = 1500;
            decimal expectedCharge1 = 0;
            decimal actualCharge1 = _orderBillingService.CalculateDeliveryCharge(amountAfterDiscount1);
            Assert.That(actualCharge1, Is.EqualTo(expectedCharge1));
            decimal amountAfterDiscount2 = 500;
            decimal expectedCharge2 = 100;
            decimal actualCharge2 = _orderBillingService.CalculateDeliveryCharge(amountAfterDiscount2);
            Assert.That(actualCharge2, Is.EqualTo(expectedCharge2));
        }
        [Test]
        public void calculateFinalAmount_Test()
        {
            decimal price = 1000;
            int quantity = 3;
            decimal expectedFinalAmount = 3000 - (3000 * 0.05m) + 0;
            decimal actualFinalAmount = _orderBillingService.CalculateFinalAmount(price, quantity);
            Assert.That(actualFinalAmount, Is.EqualTo(expectedFinalAmount));
        }
    }
}
