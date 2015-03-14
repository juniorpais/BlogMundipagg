using System;
using System.Linq;

namespace BlogMundiPagg.Repository.DAL.Repository.Base
{
    interface IGenericRepository<T> where T : class
    {
        void Add(T obj);
        void Delete(Func<T, bool> predicate);
        void Update(T obj);
        void Save();
        IQueryable<T> ListAll();
        IQueryable<T> List(Func<T, bool> predicate);
        T Find(params object[] Key);
    }
}
