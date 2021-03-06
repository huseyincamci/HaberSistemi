﻿using HaberiSistemi.Data.Model;
using System.Data.Entity;

namespace HaberiSistemi.Data.DataContext
{
    public class HaberContext : DbContext
    {
        public DbSet<Kullanici> Kullanicis { get; set; }
        public DbSet<Rol> Rols { get; set; }    
        public DbSet<Haber> Habers { get; set; }    
        public DbSet<Resim> Resims { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
    }
}
