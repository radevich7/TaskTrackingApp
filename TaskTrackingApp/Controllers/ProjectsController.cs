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
        public ActionResult Index(string SortColumn = "ProjectName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            List<Project> projects = db.Projects.ToList();

            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "ProjectID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    projects = projects.OrderBy(temp => temp.ProjectID).ToList();
                }
                else
                {
                    projects = projects.OrderByDescending(temp => temp.ProjectID).ToList();
                }
            }
            if (ViewBag.SortColumn == "ProjectName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    projects = projects.OrderBy(temp => temp.ProjectName).ToList();
                }
                else
                {
                    projects = projects.OrderByDescending(temp => temp.ProjectName).ToList();
                }
            }

            //Paging
            int NoOfRecordsPerPage = 4;

            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(projects.Count) / Convert.ToDouble(NoOfRecordsPerPage)));

            int NoOfPagesToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            projects = projects.Skip(NoOfPagesToSkip).Take(NoOfRecordsPerPage).ToList();
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
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                p.Photo = base64String;
            }
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