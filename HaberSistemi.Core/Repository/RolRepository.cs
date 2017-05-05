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
    public class RolRepository : IRolRepository
    {
        private readonly HaberContext _context;

        public RolRepository()
        {
            _context = new HaberContext();
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Rols.Select(x => x);
        }

        public Rol GetById(int id)
        {
            return _context.Rols.FirstOrDefault(x => x.Id == id);
        }

        public Rol Get(Expression<Func<Rol, bool>> filter)
        {
            return _context.Rols.FirstOrDefault(filter);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> filter)
        {
            return _context.Rols.Where(filter);
        }

        public void Insert(Rol entity)
        {
            _context.Rols.Add(entity);
        }

        public void Update(Rol entity)
        {
            _context.Rols.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var rol = GetById(id);
            if (rol != null)
                _context.Rols.Remove(rol);
        }

        public int Count()
        {
            return _context.Rols.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}