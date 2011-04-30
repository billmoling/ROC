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

        public ActionResult ShowList()
        {
            return View();
        }
        
        
        public ActionResult Index()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/IndexPic"));
            FileInfo[] fis = di.GetFiles("*.jpg");
            List<string> filepaths = new List<string>();
            for (int i = 0; i < fis.Length; i++)
            {
                filepaths.Add(string.Format("~/Content/IndexPic/{0}", fis[i].Name));
            }

            //List<string> filepaths = new List<string>();

            //for (int i = 1; i < 10; i++)
            //{
            //    filepaths.Add(string.Format("~/Content/IndexPic/0{0}.jpg",i ));
            //}


            ViewBag.IndexPicList=filepaths;



            return View(db.NewsSet.OrderByDescending(m=>m.ContentTime).Take(6).ToList());
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

        public ActionResult PicStory(int? id)
        {
            if (id.HasValue == false)
            {
                return View(db.PictureStorySet.FirstOrDefault());
            }
            else
            {
                return View(db.PictureStorySet.Find(id));
            }
        }

        public ActionResult Project()
        {
            return View();
        }

        
    }
}
