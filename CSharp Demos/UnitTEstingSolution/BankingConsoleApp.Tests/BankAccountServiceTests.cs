using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingConsoleApp.Services;
using BankingConsoleApp.Models;

namespace BankingConsoleApp.Tests
{
    [TestFixture]
    public class BankAccountServiceTests
    {
        private BankAccountService _bankAccountService;
        private BankAccount _bankAccount;

        [SetUp]
        public void SetUp()
        {
            _bankAccountService = new BankAccountService();
            _bankAccount = new BankAccount(1001,"Geetha",5000);
        }

        [Test]
        public void When_CreateAccount_ValidDetails_ReturnsBankAccount()
        {
            BankAccount account = _bankAccountService.CreateAccount(1002, "Arun", 9000);
            Assert.That(account, Is.Not.Null);
            Assert.That(account.AccountNumber, Is.EqualTo(1002));
            Assert.That(account.AccountHolderName, Is.EqualTo("Arun"));
            Assert.That(account.Balance, Is.EqualTo(9000));
        }

        [Test]
        public void When_CreateAccount_InvalidAccountNumber_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            _bankAccountService.CreateAccount(0, "Geetha", 45000));
            Assert.That(exception.Message, Is.EqualTo("Account Number must be greater tahn zero."));
        }

        [Test]
        public void When_CreateAccount_Empty_AccountHolderName_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            _bankAccountService.CreateAccount(1002, "", 45000));
            Assert.That(exception.Message, Is.EqualTo("Account holder name is required"));
        }

        [Test]
        public void When_CreateAccount_NegativeOpeningBalance_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            _bankAccountService.CreateAccount(1003, "Lalitha", -90));
            Assert.That(exception.Message, Is.EqualTo("Opening Balance caanot be negative."));
        }

        //[Test]
        //public void When_Deposit_ValidAmount_IncreaseBalance()
        //{
        //    _bankAccountService.Deposit(_bankAccount, 2000);
        //    Assert.That(_bankAccount.Balance, Is.EqualTo(7000));
        //}
        [TestCase(1000,6000)]
        [TestCase(3000,8000)]
        [TestCase(4000,9000)]
        public void When_Deposit_ValidAmount_IncreaseBalance(decimal depositAmount,decimal expecetedBalance)
        {
            _bankAccountService.Deposit(_bankAccount, depositAmount);
            Assert.That(_bankAccount.Balance, Is.EqualTo(expecetedBalance));
        }
        [Test]
        public void When_Deposit_ZeroAmount_ThrowsArgumentException()
        {
           ArgumentException exception=Assert.Throws<ArgumentException>(() =>
           _bankAccountService.Deposit(_bankAccount,0));

            Assert.That(exception.Message, Is.EqualTo("Deposit amount must be greater than zero."));
        }
        //[Test]
        //public void When_Deposit_NegativeAmount_ThrowsArgumentException()
        //{
        //    ArgumentException exception = Assert.Throws<ArgumentException>(() =>
        //    _bankAccountService.Deposit(_bankAccount,-9000));

        //    Assert.That(exception.Message, Is.EqualTo("Deposit amount must be greater than zero."));
        //}


        [TestCase(-100)]
        [TestCase(-700)]
        [TestCase(-1000)]
        public void When_Deposit_NegativeAmount_ThrowsArgumentException(decimal depositAmount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            _bankAccountService.Deposit(_bankAccount, depositAmount));

            Assert.That(exception.Message, Is.EqualTo("Deposit amount must be greater than zero."));
        }
        [Test]
        public void When_Deposit_NullAccount_ThrowsArgumentException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            _bankAccountService.Deposit(null, 9000));

            Assert.That(exception.ParamName, Is.EqualTo("account"));
        }
        [Test]
        public void When_Withdraw_ValidAmount_DecreaseBalance()
        {
            _bankAccountService.Withdraw(_bankAccount, 2000);
            Assert.That(_bankAccount.Balance, Is.EqualTo(3000));
        }

        [Test]
        public void When_Withdraw_ZeroAmount_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            _bankAccountService.Withdraw(_bankAccount, 0));

            Assert.That(exception.Message, Is.EqualTo("Withdraw amount must be greater than zero."));
        }
        [Test]
        public void When_Withdraw_NegativeAmount_ThrowsArgumentException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            _bankAccountService.Withdraw(_bankAccount, -1000));

            Assert.That(exception.Message, Is.EqualTo("Deposit amount must be greater than zero."));
        }
        [Test]
        public void When_Withdraw_AmountGreateTahnBalance_ThrowsInvalidOperationException()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            _bankAccountService.Withdraw(_bankAccount, 12000));

            Assert.That(exception.Message, Is.EqualTo("Insufficient Balance."));
        }
        [Test]
        public void When_WithDraw_NullAccount_ThrowsArgumentException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            _bankAccountService.Withdraw(null, 9000));

            Assert.That(exception.ParamName, Is.EqualTo("account"));
        }

        [Test]
        public void When_GetBalance_ValidAccount_ReturnsCurrentBalance()
        {
            decimal balance=_bankAccountService.GetBalance(_bankAccount);
            Assert.That(balance, Is.EqualTo(5000));
        }
        [Test]
        public void When_GetBalance_NullAccount_ReturnsArgumentNullException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() =>
            _bankAccountService.GetBalance(null));
            Assert.That(exception.ParamName , Is.EqualTo("account"));
        }
    }
}
