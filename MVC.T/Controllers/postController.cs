using MoviesProject.BusinessLayer;
using MoviesProject.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MVC.T.Controllers
{
    public class postController : Controller
    {
        public static readonly MoviesCRUD MovieOp = MoviesCRUD.Instance;
        // GET: post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2(int? page,string sortBy , string searchedName)
        {
            int pageSize = 5;
            int pageNumber;
            if(page == null)
            {
                pageNumber = (page ?? 1);
            }
            else
            {
                pageNumber = (int)page;
            }

            var posts = new List<Movie>();
            posts = MovieOp.GetAll();
            
            return View(posts.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult Index()
        //{
        //    var movies = MovieOp.GetAll().ToList();

        //    var items = movies.Select(m => new SelectListItem
        //    {
        //        Value = m.Id.ToString(),
        //        Text = m.Name
        //    });

        //    ViewBag.Items = items; // Pass the items list to the view using ViewBag

        //    return View(movies);
        //}


        // GET: post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: post/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: post/Edit/5
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

        // GET: post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: post/Delete/5
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
