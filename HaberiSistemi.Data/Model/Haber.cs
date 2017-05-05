using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberiSistemi.Data.Model
{
    [Table("Haber")]
    public class Haber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Haber Başlık")]
        [MaxLength(255, ErrorMessage = "Çok fazla girdiniz.")]
        public string Baslik { get; set; }

        [Display(Name = "Kısa Açıklama")]
        public string KisaAciklama { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Aktif")]
        public bool Aktif { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        public int Goruntelenme { get; set; }   

        [Display(Name = "Resim")]
        [MaxLength(255, ErrorMessage = "Çok fazla girdiniz.")]
        public string Resim { get; set; }

        [ForeignKey("Kullanici")]
        public int KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        public virtual ICollection<Resim> Resims{ get; set; }
    }
}