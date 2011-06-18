using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;
using System.IO;

namespace ROC.Controllers
{
    public class HomeController : Controller
    {
        ROCDBContainer db = new ROCDBContainer();

       
        
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult historypeople()
        {
            return View();
        }

        public ActionResult photogallary()
        {
            List<Picture> list = new List<Picture>();

            list = db.PictureSet.ToList();

            foreach (var item in list)
            {
                item.PictureName = string.Format("../Content/images/gallary/{0}.jpg",item.PictureName);
            }


            return View(list);
        }
        public ActionResult News()
        {
            return View();
        }
    }
}
