using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebs.Controllers
{
    public class Information
    {
        public int id { get; set; }
        public string FristName { get; set; }
        public string SeconedName { get; set; }
    }

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return RedirctToAc();
        }

        public ActionResult JsonResultIndex()
        {
            var info = new List<Information>
            {
                new Information{id=1, FristName="sulaiman", SeconedName="faisal"},
                new Information{id=2, FristName="faisal", SeconedName="abdullah"},
                new Information{id=3, FristName="Mohammad", SeconedName="sulaiman"},
                new Information{id=4, FristName="fahad", SeconedName="nasir"},
                new Information{id=5, FristName="abdullah", SeconedName="riyadh"},
                new Information{id=6, FristName="ahmad", SeconedName="rashed"},
                new Information{id=7, FristName="faisal", SeconedName="sulaiman"}
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConttentAction()
        {
            var Message = "Hi I am Sulaiman";
            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return JsonResultIndex();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return ConttentAction();
        }

        public ActionResult RedirctToAc()
        {
            return RedirectToAction("About", "Home");
        }

        public ActionResult edit(int id,string Name)
        {

            return Json("id= " + id + "\n name : " + Name);
            
        }
    }
}