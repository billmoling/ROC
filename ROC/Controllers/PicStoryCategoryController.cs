using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;

namespace ROC.Controllers
{
    public class PicStoryCategoryController : Controller
    {

        ROCDBContainer db = new ROCDBContainer();
        //
        // GET: /PicStoryCategory/

        public ActionResult Index()
        {
            return View(db.PictureStoryCategorySet);
        }

        //
        // GET: /PicStoryCategory/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PicStoryCategory/Create

        [HttpPost]
        public ActionResult Create(PictureStoryCategory entity)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.PictureStoryCategorySet.Add(entity);
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
        // GET: /PicStoryCategory/Edit/5
 
        public ActionResult Edit(int id)
        {
            ROC.Models.PictureStoryCategory model = db.PictureStoryCategorySet.Find(id);
            return View(model);
        }

        //
        // POST: /PicStoryCategory/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                var modelToUpdate = db.PictureStoryCategorySet.Find(id);
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
        // GET: /PicStoryCategory/Delete/5
 
        public ActionResult Delete(int id)
        {
            try
            {
                if (db.PictureStorySet.Where(m => m.CategoryID == id).Count() > 0)
                {
                    ModelState.AddModelError("", "Unable to delete this category.Still have some picstory using this category.please update these news to other category.");
                    return RedirectToAction("Index");
                }

                var modelToDelete = db.PictureStoryCategorySet.Find(id);
                db.PictureStoryCategorySet.Remove(modelToDelete);
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
