using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsychologyProject.Models;

namespace PsychologyProject.Controllers
{
    public class DocumentationTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DocumentationTypes
        public ActionResult Index()
        {
            return View(db.DocumentationTypes.ToList());
        }

        // GET: DocumentationTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentationType documentationType = db.DocumentationTypes.Find(id);
            if (documentationType == null)
            {
                return HttpNotFound();
            }
            return View(documentationType);
        }

        // GET: DocumentationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DocumentationType documentationType)
        {
            if (ModelState.IsValid)
            {
                db.DocumentationTypes.Add(documentationType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentationType);
        }

        // GET: DocumentationTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentationType documentationType = db.DocumentationTypes.Find(id);
            if (documentationType == null)
            {
                return HttpNotFound();
            }
            return View(documentationType);
        }

        // POST: DocumentationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DocumentationType documentationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentationType);
        }

        // GET: DocumentationTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentationType documentationType = db.DocumentationTypes.Find(id);
            if (documentationType == null)
            {
                return HttpNotFound();
            }
            return View(documentationType);
        }

        // POST: DocumentationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentationType documentationType = db.DocumentationTypes.Find(id);
            db.DocumentationTypes.Remove(documentationType);
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
