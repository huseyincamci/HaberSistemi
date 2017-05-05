using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HaberSistemi.Core.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Get(Expression<Func<T, bool>> filter);
        IQueryable<T> GetMany(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        int Count();
        void Save();
    }
}