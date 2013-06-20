using App.Infra;
using App.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    class EFRepositoryTest
    {
        EFRepository repo = null;

        [SetUp]
        public void SetUp()
        {
            var filePath = @"bank_test.sdf";
            if (File.Exists(filePath)) File.Delete(filePath);
            string connectionString = "Data Source = " + filePath;
            var connFac = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
            Database.DefaultConnectionFactory = connFac;
            repo = new EFRepository(connectionString);
        }

        [TearDown]
        public void TearDown()
        {
            repo.Dispose();
        }

        [Test]
        public void CreateAndRetrieveAccount()
        {
            // Arrange in SetUp

            // Act
            var acc = new Account("001", 100.0m);
            repo.Create(acc);

            var results = repo.Query<Account>();

            // Assert
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.That(results.First().AccountNo, Is.EqualTo("001"));
        }
    }
}

