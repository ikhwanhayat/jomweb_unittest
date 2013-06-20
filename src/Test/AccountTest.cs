using App.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class AccountTest
    {
        [SetUp]
        public void SetUp()
        {
            account = new Account("001", 100.0m);
        }

        Account account = null;

        [Test]
        public void CreateAccount()
        {
            // Arrange, Act
            var account = new Account("001", 100.0m);

            // Assert
            Assert.That(account.AccountNo, Is.EqualTo("001"));
            Assert.That(account.Balance, Is.EqualTo(100.0m));
        }

        [Test]
        public void DepositMoney()
        {
            // Arrange in SetUp

            // Act
            account.Deposit(10.0m);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(110.0m));
        }

        [Test]
        public void WithdrawMoney()
        {
            // Arrange in SetUp

            // Act
            account.Withdraw(10.0m);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(90.0m));
        }

        [Test]
        public void WithdrawMoreThanBalance()
        {            
            var ex = Assert.Throws<InsufficientFundsException>(() => account.Withdraw(110.0m));
        }
    }
}
