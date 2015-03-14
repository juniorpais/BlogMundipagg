using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace BlogMundiPagg.Repository.DAL.Repository.Base
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        Context.Context context = new Context.Context();

        public IQueryable<T> ListAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> List(Func<T, bool> predicate)
        {
            return ListAll().Where(predicate).AsQueryable();
        }

        public T Find(params object[] key)
        {
            return context.Set<T>().Find(key);
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Add(T obj)
        {
            context.Set<T>().Add(obj);
        }

        public void Delete(Func<T, bool> predicate)
        {
            context.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => context.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
