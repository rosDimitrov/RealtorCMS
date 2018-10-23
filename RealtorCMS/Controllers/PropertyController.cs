using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorCMS.Models;
using System.IO;
using RealtorCMS.Repository;

namespace RealtorCMS.Controllers
{
    public class PropertyController : Controller
    {
        private CMSRepository repository;
        public CMSRepository Repository {
            get
            {
                if(this.repository == null)
                {
                    this.repository = new CMSRepository();
                }
                return this.repository;
            }
        }

        // GET: Property
        public ActionResult Index()
        {
            return View(Repository.GetAllProperties());
        }

        // GET: Property/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = Repository.FindPropertyById(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyViewModel property)
        {
            if (ModelState.IsValid)
            {
                if (property.File.ContentLength > 0)
                {
                    Repository.CreateProperty(property);
                    return RedirectToAction("Index");
                }
            }

            return View(property);
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

                Property property = Repository.FindPropertyById(id);
                if (property == null)
                {
                    return HttpNotFound();
                }
                      
            return View(property);
        }

        // POST: Property/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,City,Address,PropertyType,SquareFeet,NumberOfBaths,NumberOfBeds,Description,Price,ImagePath,MapLink,YouTubeLink,IsFeatured,CreateDate")] Property property)
        {
            if (ModelState.IsValid)
            {
                Repository.EditProperty(property);
                return RedirectToAction("Index");
            }
            return View(property);
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = Repository.FindPropertyById(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repository.RemoveProperty(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
