using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PsychologyProject.Models;
using PsychologyProject.Models.ViewModel;

namespace PsychologyProject.Controllers
{
    public class PublicController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Public
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        // GET: Public/Details/5
        public ActionResult Details(int? id )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            PublicProject vm = new PublicProject();
            vm.Projects = db.Projects.Where(pr => pr.Id == id).ToList();
            vm.Experiments = db.Experiments.ToList();
            vm.Documentation = db.Documentations.ToList();


            return View(vm);
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
