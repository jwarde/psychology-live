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
    public class TestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tests
        public ActionResult Index()
        {
            return View(db.Tests.ToList());
        }

        // GET: Tests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tests tests = db.Tests.Find(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            return View(tests);
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Tests tests)
        {
            if (ModelState.IsValid)
            {
                db.Tests.Add(tests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tests);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tests tests = db.Tests.Find(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            return View(tests);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Tests tests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tests);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tests tests = db.Tests.Find(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            return View(tests);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tests tests = db.Tests.Find(id);
            db.Tests.Remove(tests);
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
