using App.Controllers;
using App.Infra;
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
    class AccountsControllerTest
    {
        [Test]
        public void TestTransfer()
        {
            // Arrange
            var acc1 = new Account("001", 100);

            var acc2 = new Account("002", 100);

            var mockRepo = new Mock<IRepository>();
            mockRepo.Setup(x => x.Get<Account>(acc1.Id)).Returns(acc1);
            mockRepo.Setup(x => x.Get<Account>(acc2.Id)).Returns(acc2);
            
            // Act
            var ctlr = new AccountsController(mockRepo.Object);
            ctlr.Transfer(acc1.Id, acc2.Id, 10);

            // Assert
            Assert.That(ctlr.TempData["Message"], Is.EqualTo("Transfer successful."));

            Assert.That(acc1.Balance, Is.EqualTo(90.0m));
            Assert.That(acc2.Balance, Is.EqualTo(110.0m));

            mockRepo.Verify(x => x.Update(acc1), Times.Once());
            mockRepo.Verify(x => x.Update(acc2), Times.Once());
        }
    }
}
