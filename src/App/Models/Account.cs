using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class Account
    {
        [Key]
        public virtual Guid Id { get; set; }

        public virtual string AccountNo { get; set; }
        public virtual decimal Balance { get; set; }

        public virtual string DisplayName { get { return String.Format("{0} (Balance: RM{1:0.00})", AccountNo, Balance); } }

        public Account()
        {
            Id = Guid.NewGuid();
        }

        public Account(string accountNo, decimal initialBalance) : this()
        {
            this.AccountNo = accountNo;
            this.Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (this.Balance < amount)
                throw new InsufficientFundsException();

            this.Balance -= amount;
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException() : base("Insufficient funds.")
        {
        }
    }
}