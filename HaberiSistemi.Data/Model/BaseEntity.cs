using System;
using System.ComponentModel.DataAnnotations;

namespace HaberiSistemi.Data.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        [Display(Name = "Aktif")]
        public bool Aktif { get; set; } = true;
    }
}