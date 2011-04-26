using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;

namespace ROC.Controllers
{
    public class HomeController : Controller
    {
        ROCDBContainer db = new ROCDBContainer();

        public ActionResult Index()
        {

            return View(db.NewsSet.OrderByDescending(m=>m.ContentTime).Take(5).ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult News(int? CategoryId)
        {

            ViewBag.NewsCategotyList = db.NewsCategorySet.ToList();


            IList<ROC.Models.News> model;
            if (CategoryId==null)
	        {
		        model=db.NewsSet.OrderByDescending(m=>m.ContentTime).ToList();
	        }
            else
            {
                model=db.NewsSet.OrderByDescending(m => m.ContentTime).Where(j=>j.CategoryID.Equals(CategoryId)).ToList();
            }   
                
            return View(model);
        }

        public ActionResult NewsDetail(int? id)
        {
            ViewBag.NewsCategotyList = db.NewsCategorySet.ToList();
            ROC.Models.News model = db.NewsSet.Find(id);
            return View(model);
        }

        public ActionResult PicStory()
        {
            return View(db.PictureStorySet);
        }
    }
}
