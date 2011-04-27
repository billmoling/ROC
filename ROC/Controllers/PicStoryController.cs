using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;

namespace ROC.Controllers
{
    public class PicStoryController : Controller
    {
        ROCDBContainer db = new ROCDBContainer();

        //
        // GET: /PicStory/

        public ActionResult Index()
        {
            return View(db.PictureStorySet);
        }


        //
        // GET: /PicStory/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PicStory/Create

        [HttpPost]
        public ActionResult Create(PictureStory entity)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        
                        db.PictureStorySet.Add(entity);
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
        // GET: /PicStory/Edit/5
 
        public ActionResult Edit(int id)
        {
            ROC.Models.PictureStory model = db.PictureStorySet.Find(id);
            model.PicStoryCategoryList = db.PictureStoryCategorySet.AsEnumerable();
            return View();
        }

        //
        // POST: /PicStory/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var modelToUpdate = db.PictureStorySet.Find(id);

                TryUpdateModel(modelToUpdate, collection.ToValueProvider());

                try
                {
                    if (ModelState.IsValid)
                    {

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
        // GET: /PicStory/Delete/5
 
        public ActionResult Delete(int id)
        {
            var modelToDelete = db.PictureStorySet.Find(id);
            db.PictureStorySet.Remove(modelToDelete);
            db.SaveChanges();
            return View();
        }

       
    }
}
