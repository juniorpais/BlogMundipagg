using System.Data.Entity;
using BlogMundiPagg.Repository.Entities;

namespace BlogMundiPagg.Repository.DAL.Context
{
   public class Context : DbContext
    {
        public Context() : base("ConnDB") { }

    }
}

