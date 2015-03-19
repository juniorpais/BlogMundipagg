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
    public class HomeController : Controller
    {
        [Inject]
        public IPostRepository repPost { get; set; }


        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Home/Details/5
        public ActionResult Details(int? id)
        {
            Post post;

            if (id == null)
                post = repPost.ListAll().ToList().Last();
            
            else
                 post = repPost.Find(id);

            if (post == null)
                return HttpNotFound();
            
            //ViewBag.UsuarioID = new SelectList(repPost.Usuarios, "UsuarioID", "Nome", post.UsuarioID);
            return View(post);
        }

        public ActionResult ListarPosts()
        {
            return PartialView(repPost.ListAll().ToList());
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
