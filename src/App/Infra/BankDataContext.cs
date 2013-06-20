using App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace App.Infra
{
    public class BankDataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public BankDataContext(string connectionString) : base(connectionString)
        {
            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        }
    }
}