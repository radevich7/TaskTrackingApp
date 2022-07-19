using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskTrackingApp.Models;

namespace TaskTrackingApp.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Index()
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            List<Project> projects = db.Projects.ToList();



            return View(projects);
        }
        //
        public ActionResult Details(long id)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();

            Project project = db.Projects.Where(temp => temp.ProjectID == id).FirstOrDefault();

            return View(project);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Project p)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            db.Projects.Add(p);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}