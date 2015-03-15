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

namespace BlogMundipagg.Web.Controllers
{
    public class UsuarioController : Controller
    {
        //private Context db = new Context();

        private readonly UsuarioRepository repUsuario = new UsuarioRepository();

        // GET: /Usuario/
        public ActionResult Index()
        {
            return View(repUsuario.ListAll().ToList());
        }

        // GET: /Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = repUsuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: /Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UsuarioID,Nome,Email,DataCadastro,Foto,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                repUsuario.Add(usuario);
                repUsuario.Save();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: /Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = repUsuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UsuarioID,Nome,Email,DataCadastro,Foto,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                repUsuario.Update(usuario);
                repUsuario.Save();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: /Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = repUsuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repUsuario.Delete(u => u.UsuarioID.Equals(id));
            repUsuario.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repUsuario.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
