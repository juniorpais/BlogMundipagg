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

using BlogMundiPagg.Repository.Entities;
using BlogMundiPagg.Repository.DAL.Context;
using BlogMundiPagg.Repository.DAL.Repository;

using Ninject;

namespace BlogMundiPagg.Web.Controllers
{
    public class PostController : Controller
    {
        [Inject]
        public IPostRepository repPost { get; set; }

        //private Context repPost = new Context();

        // GET: /Post/
        public ActionResult Index()
        {
            return View(repPost.ListAll().ToList());
        }

        // GET: /Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repPost.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: /Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PostID,Titulo,DataCadastro,Corpo,UsuarioID")] Post post)
        {
            if (ModelState.IsValid)
            {
                repPost.Add(post);
                repPost.Save();
                return RedirectToAction("Index");
            }

           // ViewBag.UsuarioID = new SelectList(repPost.Usuarios, "UsuarioID", "Nome", post.UsuarioID);
            return View(post);
        }

        // GET: /Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repPost.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UsuarioID = new SelectList(repPost.Usuarios, "UsuarioID", "Nome", post.UsuarioID);
            return View(post);
        }

        // POST: /Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PostID,Titulo,DataCadastro,Corpo,UsuarioID")] Post post)
        {
            if (ModelState.IsValid)
            {
                repPost.Update(post);
                repPost.Save();
                return RedirectToAction("Index");
            }
               return View(post);
        }

        // GET: /Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = repPost.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repPost.Delete(p => p.PostID.Equals(id));
            repPost.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repPost.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
