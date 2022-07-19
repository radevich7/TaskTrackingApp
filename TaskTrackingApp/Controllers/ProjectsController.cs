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
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            ViewBag.Categories = db.Categories.ToList();
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

        public ActionResult Edit(long id)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            ViewBag.Categories = db.Categories.ToList();
            Project existingProject = db.Projects.Where(temp => temp.ProjectID == id).FirstOrDefault();
            return View(existingProject);
        }

        [HttpPost]
        public ActionResult Edit(Project p)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            Project existingProject = db.Projects.Where(temp => temp.ProjectID == p.ProjectID).FirstOrDefault();
            existingProject.ProjectName = p.ProjectName;
            existingProject.DateOfStart = p.DateOfStart;
            existingProject.AvailabilityStatus = p.AvailabilityStatus;
            existingProject.CategoryID = p.CategoryID;
            db.SaveChanges();

            return RedirectToAction("Index", "Projects");
        }
        public ActionResult Delete(long id)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            Project existingProject = db.Projects.Where(temp => temp.ProjectID == id).FirstOrDefault();
            return View(existingProject);
        }

        [HttpPost]
        public ActionResult Delete(long id, Project p)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            Project existingProject = db.Projects.Where(temp => temp.ProjectID == id).FirstOrDefault();
            db.Projects.Remove(existingProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}