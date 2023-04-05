using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Models;

namespace WebApplication16.Controllers
{
    public class LoginTablesController : Controller
    {
        private CreateDbEntities db = new CreateDbEntities();

        // GET: LoginTables
        public ActionResult Index()
        {
            return View(db.LoginTables.ToList());
        }

        // GET: LoginTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginTable loginTable = db.LoginTables.Find(id);
            if (loginTable == null)
            {
                return HttpNotFound();
            }
            return View(loginTable);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            LoginTable user = db.LoginTables.Find(username);
            string a = user.Username;
            string b = user.Password;
            if (user.Username != null)
            {
                if (user.Password == password)
                {
                    return View("Index");
                }
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        // GET: LoginTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password")] LoginTable loginTable)
        {
            if (ModelState.IsValid)
            {
                db.LoginTables.Add(loginTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginTable);
        }

        // GET: LoginTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginTable loginTable = db.LoginTables.Find(id);
            if (loginTable == null)
            {
                return HttpNotFound();
            }
            return View(loginTable);
        }

        // POST: LoginTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password")] LoginTable loginTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginTable);
        }

        // GET: LoginTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginTable loginTable = db.LoginTables.Find(id);
            if (loginTable == null)
            {
                return HttpNotFound();
            }
            return View(loginTable);
        }

        // POST: LoginTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoginTable loginTable = db.LoginTables.Find(id);
            db.LoginTables.Remove(loginTable);
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
