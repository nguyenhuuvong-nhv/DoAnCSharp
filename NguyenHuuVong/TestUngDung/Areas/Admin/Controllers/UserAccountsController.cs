using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserAccountsController : Controller
    {
        private NHVongContext db = new NHVongContext();

        // GET: Admin/UserAccounts
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            if (Session[Constants.USER_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var user = new UserDAO();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            if (Session[Constants.USER_SESSION] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var user = new UserDAO();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        // GET: Admin/UserAccounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: Admin/UserAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/UserAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,Password,Status")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.UserName.Trim();
                userAccount.UserID = new UserDAO().getNewUserID();
                userAccount.Password= Encryptor.EncryptMD5(userAccount.Password.Trim());
                db.UserAccount.Add(userAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccount);
        }

        // GET: Admin/UserAccounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: Admin/UserAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Password,Status")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.Password = Encryptor.EncryptMD5(userAccount.Password.Trim());
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }

        // GET: Admin/UserAccounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: Admin/UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserAccount userAccount = db.UserAccount.Find(id);
            db.UserAccount.Remove(userAccount);
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
