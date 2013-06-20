using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class MoneyTransfer
    {
        public MoneyTransfer(Account source, Account sink, decimal amount)
        {
            this.Source = source;
            this.Sink = sink;

            // Do transfer
            this.Source.Withdraw(amount);
            this.Sink.Deposit(amount);

            this.Amount = amount;
            this.Date = DateTime.Now;
        }

        public virtual Account Source { get; set; }
        public virtual Account Sink { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual DateTime Date { get; set; }

    }
}
