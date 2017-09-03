using NicaWallet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace NicaWallet.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.accounts = dbContext.Account
                                   .Include(a => a.AccountType)
                                   .Include(a => a.Currency)
                                   .Where(x => x.UserId.Equals(userId))
                                   .Take(3)
                                   .ToList();
            ViewBag.records = dbContext.Record.Include(r => r.Account)
                              .Include(r => r.Category)
                              .Include(r => r.Currency)
                              .Take(10)
                              .ToList();
            //LastMonths();
            return View();
        }

        [HttpGet]
        public ActionResult LastMonths()
        {
            string userId = User.Identity.GetUserId();
            DateTime dt_inicio = DateTime.Now.AddMonths(-1);
            DateTime dt_fin = DateTime.Now;
            var data = (from r in dbContext.Record
                        join a in dbContext.Account on r.AccountId equals a.AccountId
                        where (a.UserId == userId) && (r.RecordDateInsert >= dt_inicio) && (r.RecordDateInsert <= dt_fin)
                        && (r.PaymentType == true)
                        select new
                        {
                            r.Amount,
                            a.AccountName
                        }).Sum(x => x.Amount);
            return Json(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}