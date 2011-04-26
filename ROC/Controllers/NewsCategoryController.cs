using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;

namespace ROC.Controllers
{
    public class NewsCategoryController : Controller
    {
        ROCDBContainer db = new ROCDBContainer();

        public ActionResult ShowList()
        {
            
            return View();
        }
        
        
        //
        // GET: /NewsCategory/

        public ActionResult Index()
        {
            return View(db.NewsCategorySet);
        }

        //
        // GET: /NewsCategory/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /NewsCategory/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /NewsCategory/Create

        [HttpPost]
        public ActionResult Create(NewsCategory entity)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.NewsCategorySet.Add(entity);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
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
        // GET: /NewsCategory/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /NewsCategory/Edit/5

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
        // GET: /NewsCategory/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /NewsCategory/Delete/5

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
