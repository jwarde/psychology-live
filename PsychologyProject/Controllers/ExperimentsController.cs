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
    public class ExperimentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Experiments
        public ActionResult Index()
        {
            var experiments = db.Experiments.Include(e => e.Project);
            return View(experiments.ToList());
        }

        // GET: Experiments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiment experiment = db.Experiments.Find(id);
            if (experiment == null)
            {
                return HttpNotFound();
            }
            return View(experiment);
        }

        // GET: Experiments/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: Experiments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Location,Date,Time,ProjectId,ReportTo,AimsAndObjectives,Brief,Debrief,Active")] Experiment experiment)
        {
            if (ModelState.IsValid)
            {
                db.Experiments.Add(experiment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", experiment.ProjectId);
            return View(experiment);
        }

        // GET: Experiments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiment experiment = db.Experiments.Find(id);
            if (experiment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", experiment.ProjectId);
            return View(experiment);
        }

        // POST: Experiments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Location,Date,Time,ProjectId,ReportTo,AimsAndObjectives,Brief,Debrief,Active")] Experiment experiment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experiment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", experiment.ProjectId);
            return View(experiment);
        }

        // GET: Experiments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiment experiment = db.Experiments.Find(id);
            if (experiment == null)
            {
                return HttpNotFound();
            }
            return View(experiment);
        }

        // POST: Experiments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Experiment experiment = db.Experiments.Find(id);
            db.Experiments.Remove(experiment);
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
