using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;

namespace ROC.Controllers
{
    [Authorize]
    public class NewsCategoryController : Controller
    {
        ROCDBContainer db = new ROCDBContainer();

        //
        // GET: /NewsCategory/

        public ActionResult Index()
        {
            return View(db.NewsCategorySet);
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
            ROC.Models.NewsCategory model = db.NewsCategorySet.Find(id);
            return View(model);
        }

        //
        // POST: /NewsCategory/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var modelToUpdate = db.NewsCategorySet.Find(id);
                TryUpdateModel(modelToUpdate, collection.ToValueProvider());

                try
                {
                    if (ModelState.IsValid)
                    { 
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
        // GET: /NewsCategory/Delete/5
 
        public ActionResult Delete(int id)
        {
            try
            {
                if (db.NewsSet.Where(m => m.CategoryID == id).Count() > 0)
                {
                    ModelState.AddModelError("", "Unable to delete this category.Still have some news using this category.please update these news to other category.");
                    return RedirectToAction("Index");
                }

                var modelToDelete = db.NewsCategorySet.Find(id);
                db.NewsCategorySet.Remove(modelToDelete);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

       
    }
}
