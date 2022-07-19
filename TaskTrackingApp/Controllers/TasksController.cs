using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskTrackingApp.Models;
namespace TaskTrackingApp.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            List<Task> tasks = db.Tasks.ToList();

            return View(tasks);
        }
    }
}