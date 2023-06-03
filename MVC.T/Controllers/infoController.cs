using MVC.T.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.T.Controllers
{
    [RoutePrefix("TestT")]
    public class infoController : Controller
    {
        // GET: info
        [Route("News")]
        [HttpGet]
        public ActionResult News()
        {
            var news = new List<news>
            { 
                new news
                {
                  id = 1,
                 Title = "azoz68",
                 details = "this is the details of the news" + "Hello sulaiman",
                 newsDate = DateTime.Now.ToShortDateString()
                }
             };

            return View(news);
        }
        [Route("Type")]
        [HttpGet]
        public ActionResult Type()
        {
            return View();
        }

    }
}