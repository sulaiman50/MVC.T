using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.T.Controllers
{
    public class newsController : Controller
    {
        // GET: news
        public ActionResult Index()
        {
            return View();
        }

        // GET: news/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: news/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: news/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("news", "info");
            }
            catch
            {
                return View();
            }
        }

        // GET: news/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: news/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: news/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: news/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
