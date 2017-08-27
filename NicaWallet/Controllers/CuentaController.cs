using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NicaWallet.Models;

namespace NicaWallet.Controllers
{
    public class CuentaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cuenta
        public ActionResult Index()
        {
            var account = db.Account.Include(a => a.AccountType).Include(a => a.Currency);
            return View(account.ToList());
        }

        // GET: Cuenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Cuenta/Create
        public ActionResult Create()
        {
            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName");
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName");
            return View();
        }

        // POST: Cuenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,AccountName,Amount,CreatedDate,LastUpdate,IsActive,UserId,Color,CurrencyId,AccountTypeId")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Account.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName", account.AccountTypeId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", account.CurrencyId);
            return View(account);
        }

        // GET: Cuenta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName", account.AccountTypeId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", account.CurrencyId);
            return View(account);
        }

        // POST: Cuenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,AccountName,Amount,CreatedDate,LastUpdate,IsActive,UserId,Color,CurrencyId,AccountTypeId")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName", account.AccountTypeId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", account.CurrencyId);
            return View(account);
        }

        // GET: Cuenta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Account.Find(id);
            db.Account.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
