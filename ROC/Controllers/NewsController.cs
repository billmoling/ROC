using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ROC.Models;

namespace ROC.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        ROCDBContainer db = new ROCDBContainer();

        //
        // GET: /News/
        
        public ActionResult Index()
        {
            List<News> list = new List<News>();

            list=db.NewsSet.OrderByDescending(m => m.ContentTime).ToList();

            foreach (var item in list)
            {
                item.CategorysList = db.NewsCategorySet.AsEnumerable();
            }


            return View(list);
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
            ROC.Models.News model = db.NewsSet.Find(id);
            model.ModifiedTime=DateTime.Now;
            model.CategorysList = db.NewsCategorySet.AsEnumerable();

            return View(model);
        }

        //
        // POST: /News/Edit/5

        [HttpPost,ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var modelToUpdate = db.NewsSet.Find(id);
                
                TryUpdateModel(modelToUpdate, collection.ToValueProvider());

                try
                {
                    if (ModelState.IsValid)
                    {
                        modelToUpdate.ModifiedTime = DateTime.Now;
                        
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
