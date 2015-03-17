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
    public class PostTagController : Controller
    {
        [Inject]
        public IPostTagRepository repPostTag { get; set; }
                
        // GET: /PostTag/
        public ActionResult Index()
        {
            return View(repPostTag.ListAll().ToList());
        }

        // GET: /PostTag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTag posttag = repPostTag.Find(id);
            if (posttag == null)
            {
                return HttpNotFound();
            }
            return View(posttag);
        }

        // GET: /PostTag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PostTag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PostTagID")] PostTag posttag)
        {
            if (ModelState.IsValid)
            {
                repPostTag.Add(posttag);
                repPostTag.Save();
                return RedirectToAction("Index");
            }

            return View(posttag);
        }

        // GET: /PostTag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTag posttag = repPostTag.Find(id);
            if (posttag == null)
            {
                return HttpNotFound();
            }
            return View(posttag);
        }

        // POST: /PostTag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PostTagID")] PostTag posttag)
        {
            if (ModelState.IsValid)
            {
                repPostTag.Update(posttag);
                repPostTag.Save();
                return RedirectToAction("Index");
            }
            return View(posttag);
        }

        // GET: /PostTag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostTag posttag = repPostTag.Find(id);
            if (posttag == null)
            {
                return HttpNotFound();
            }
            return View(posttag);
        }

        // POST: /PostTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repPostTag.Delete(p => p.PostTagID.Equals(id));
            repPostTag.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repPostTag.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
