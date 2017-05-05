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
    public class HaberRepository : IHaberRepository
    {
        private readonly HaberContext _context;

        public HaberRepository()
        {
            _context = new HaberContext();
        }

        public IEnumerable<Haber> GetAll()
        {
            return _context.Habers.Select(x => x);
        }

        public Haber GetById(int id)
        {
            return _context.Habers.FirstOrDefault(x => x.Id == id);
        }

        public Haber Get(Expression<Func<Haber, bool>> filter)
        {
            return _context.Habers.FirstOrDefault(filter);
        }

        public IQueryable<Haber> GetMany(Expression<Func<Haber, bool>> filter)
        {
            return _context.Habers.Where(filter);
        }

        public void Insert(Haber entity)
        {
            _context.Habers.Add(entity);
        }

        public void Update(Haber entity)
        {
            _context.Habers.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var haber = GetById(id);
            if (haber != null)
                _context.Habers.Remove(haber);
        }

        public int Count()
        {
            return _context.Habers.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}