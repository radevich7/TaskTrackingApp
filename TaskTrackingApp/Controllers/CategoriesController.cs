using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskTrackingApp.Models;



namespace TaskTrackingApp.Controllers
{
    public class CategoriesController : Controller
    {

        //GET: Categories
        public ActionResult Index(string search = "")
        {

            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            ViewBag.search = search;

            List<Category> categories = db.Categories.Where(temp => temp.CategoryName.Contains(search)).ToList();


            return View(categories);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category p)
        {
            TaskTrackingAppEntities db = new TaskTrackingAppEntities();
            db.Categories.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}