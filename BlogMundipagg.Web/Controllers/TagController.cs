using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMundiPagg.Repository.Entities;
using BlogMundiPagg.Repository.DAL.Context;
using BlogMundiPagg.Repository.DAL.Repository;
using Ninject;

namespace BlogMundiPagg.Web.Controllers
{
    public class TagController : Controller
    {
        [Inject]
        public ITagRepository repTag { get; set; }
               
        // GET: /Tag/
        public ActionResult Index()
        {
            return View(repTag.ListAll().ToList());
        }

        // GET: /Tag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = repTag.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: /Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="TagID,Descricao")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                repTag.Add(tag);
                repTag.Save();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: /Tag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = repTag.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: /Tag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="TagID,Descricao")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                repTag.Update(tag);
                repTag.Save();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: /Tag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = repTag.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: /Tag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repTag.Delete(t => t.TagID.Equals(id));
            repTag.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repTag.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
