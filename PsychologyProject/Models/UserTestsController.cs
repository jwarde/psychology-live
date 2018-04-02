using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PsychologyProject.Models
{
    public class UserTestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserTests
        public ActionResult Index()
        {
            return View(db.UserTests.ToList());
        }

        // GET: UserTests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTests userTests = db.UserTests.Find(id);
            if (userTests == null)
            {
                return HttpNotFound();
            }
            return View(userTests);
        }

        // GET: UserTests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserTests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TestId,ReasonForTestUsed,TestRawData,TestReturnedData,Result,Interpretation")] UserTests userTests)
        {
            if (ModelState.IsValid)
            {
                db.UserTests.Add(userTests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userTests);
        }

        // GET: UserTests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTests userTests = db.UserTests.Find(id);
            if (userTests == null)
            {
                return HttpNotFound();
            }
            return View(userTests);
        }

        // POST: UserTests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TestId,ReasonForTestUsed,TestRawData,TestReturnedData,Result,Interpretation")] UserTests userTests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userTests);
        }

        // GET: UserTests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTests userTests = db.UserTests.Find(id);
            if (userTests == null)
            {
                return HttpNotFound();
            }
            return View(userTests);
        }

        // POST: UserTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTests userTests = db.UserTests.Find(id);
            db.UserTests.Remove(userTests);
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
