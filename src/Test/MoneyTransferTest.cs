using App.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    class MoneyTransferTest
    {
        [Test]
        public void TransferMoney()
        {
            // Arrange
            var mockAcc1 = new Mock<Account>();
            mockAcc1.SetupGet(x => x.Balance).Returns(100.0m);
            var mockAcc2 = new Mock<Account>();

            // Act
            var moneyTransfer = new MoneyTransfer(mockAcc1.Object, mockAcc2.Object, 10.0m);

            // Assert
            mockAcc1.Verify(x => x.Withdraw(10.0m), Times.Once());
            mockAcc2.Verify(x => x.Deposit(10.0m), Times.Once());

            Assert.That(moneyTransfer.Amount, Is.EqualTo(10.0m));
            Assert.That(moneyTransfer.Date.ToShortDateString(), 
                        Is.EqualTo(DateTime.Now.ToShortDateString()));
        }
    }
}
