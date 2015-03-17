using System.Data.Entity;
using BlogMundiPagg.Repository.Entities;

namespace BlogMundiPagg.Repository.DAL.Context
{
   public class Context : DbContext
    {
        public Context() : base("ConnDB") { }

        public System.Data.Entity.DbSet<BlogMundiPagg.Repository.Entities.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<BlogMundiPagg.Repository.Entities.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<BlogMundiPagg.Repository.Entities.PostTag> PostTags { get; set; }

        public System.Data.Entity.DbSet<BlogMundiPagg.Repository.Entities.Tag> Tags { get; set; }

    }
}

