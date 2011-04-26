using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;

namespace ROC.Controllers
{
    public class NewsController : Controller
    {
        ROCDBContainer db = new ROCDBContainer();

        //
        // GET: /News/

        public ActionResult Index()
        {
            

            return View(db.NewsSet);
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /News/Create
        
        public ActionResult Create()
        {
            var model = new News()
            {
                ModifiedTime = DateTime.Now,
                ContentTime=DateTime.Now,
                CategorysList=db.NewsCategorySet.AsEnumerable()
            };



            return View(model);
        } 

        //
        // POST: /News/Create

        [HttpPost,ValidateInput(false)]
        public ActionResult Create(News entity)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        entity.ModifiedTime = DateTime.Now;
                        db.NewsSet.Add(entity);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    //Log the error (add a variable name after DataException)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                } 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /News/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /News/Edit/5

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

        //
        // GET: /News/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /News/Delete/5

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
