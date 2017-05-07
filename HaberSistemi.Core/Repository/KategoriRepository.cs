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
    public class KategoriRepository : IKategoriRepository
    {
        private readonly HaberContext _context;

        public KategoriRepository()
        {
            _context = new HaberContext();
        }

        public IEnumerable<Kategori> GetAll()
        {
            return _context.Kategoris.Select(x => x);
        }

        public Kategori GetById(int id)
        {
            return _context.Kategoris.FirstOrDefault(x => x.Id == id);
        }

        public Kategori Get(Expression<Func<Kategori, bool>> filter)
        {
            return _context.Kategoris.FirstOrDefault(filter);
        }

        public IQueryable<Kategori> GetMany(Expression<Func<Kategori, bool>> filter)
        {
            return _context.Kategoris.Where(filter);
        }

        public void Insert(Kategori entity)
        {
            _context.Kategoris.Add(entity);
        }

        public void Update(Kategori entity)
        {
            _context.Habers.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var kategori = GetById(id);
            if (kategori != null)
                _context.Kategoris.Remove(kategori);
        }

        public int Count()
        {
            return _context.Kategoris.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}