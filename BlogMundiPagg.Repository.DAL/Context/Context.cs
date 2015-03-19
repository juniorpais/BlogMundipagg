using System.Data.Entity;
using BlogMundiPagg.Repository.Entities;

namespace BlogMundiPagg.Repository.DAL.Context
{
   public class Context : DbContext
    {
        public Context() : base("ConnDB") { }

        public System.Data.Entity.DbSet<Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<Post> Posts { get; set; }

        public System.Data.Entity.DbSet<PostTag> PostTags { get; set; }

        public System.Data.Entity.DbSet<Tag> Tags { get; set; }

    }
}

