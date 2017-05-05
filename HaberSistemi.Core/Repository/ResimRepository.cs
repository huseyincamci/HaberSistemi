using HaberiSistemi.Data.DataContext;
using HaberiSistemi.Data.Model;
using HaberSistemi.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace HaberSistemi.Core.Repository
{
    public class ResimRepository : IResimRepository
    {
        private readonly HaberContext _context;

        public ResimRepository()
        {
            _context = new HaberContext();
        }

        public IEnumerable<Resim> GetAll()
        {
            return _context.Resims.Select(x => x);
        }

        public Resim GetById(int id)
        {
            return _context.Resims.FirstOrDefault(x => x.Id == id);
        }

        public Resim Get(Expression<Func<Resim, bool>> filter)
        {
            return _context.Resims.FirstOrDefault(filter);
        }

        public IQueryable<Resim> GetMany(Expression<Func<Resim, bool>> filter)
        {
            return _context.Resims.Where(filter);
        }

        public void Insert(Resim entity)
        {
            _context.Resims.Add(entity);
        }

        public void Update(Resim entity)
        {
            _context.Resims.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var resim = GetById(id);
            if (resim != null)
                _context.Resims.Remove(resim);
        }

        public int Count()
        {
            return _context.Resims.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}