using App.Infra;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class AccountsController : Controller
    {
        IRepository repo;

        public AccountsController(IRepository repo)
        {
            this.repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Accounts = repo.Query<Account>().ToList();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Account account)
        {
            repo.Create(account);

            TempData["Message"] = "Create successful.";
            return RedirectToAction("Index");
        }

        public ActionResult Transfer(Guid id)
        {
            ViewBag.SourceAccount = repo.Get<Account>(id);
            ViewBag.SinkAccounts = repo.Query<Account>().Where(x => x.Id != id);

            return View();
        }

        [HttpPost]
        public ActionResult Transfer(Guid sourceId, Guid sinkId, decimal amount)
        {
            var source = repo.Get<Account>(sourceId);
            var sink = repo.Get<Account>(sinkId);

            var moneyTransfer = new MoneyTransfer(source, sink, amount);

            repo.Update(source);
            repo.Update(sink);

            TempData["Message"] = "Transfer successful.";
            return RedirectToAction("Index");
        }
    }
}

