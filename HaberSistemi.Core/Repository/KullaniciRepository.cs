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
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly HaberContext _context;

        public KullaniciRepository()
        {
            _context = new HaberContext();
        }

        public IEnumerable<Kullanici> GetAll()
        {
            return _context.Kullanicis.Select(x => x);
        }

        public Kullanici GetById(int id)
        {
            return _context.Kullanicis.FirstOrDefault(x => x.Id == id);
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> filter)
        {
            return _context.Kullanicis.FirstOrDefault(filter);
        }

        public IQueryable<Kullanici> GetMany(Expression<Func<Kullanici, bool>> filter)
        {
            return _context.Kullanicis.Where(filter);
        }

        public void Insert(Kullanici entity)
        {
            _context.Kullanicis.Add(entity);
        }

        public void Update(Kullanici entity)
        {
            _context.Kullanicis.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var kullanici = GetById(id);
            if (kullanici != null)
                _context.Kullanicis.Remove(kullanici);
        }

        public int Count()
        {
            return _context.Kullanicis.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}