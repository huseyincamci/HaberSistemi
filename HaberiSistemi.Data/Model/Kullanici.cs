using System;
using System.ComponentModel.DataAnnotations;

namespace HaberiSistemi.Data.Model
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ad Soyad")]
        [MaxLength(50, ErrorMessage = "Lütfen 50 karakterden fazla değer girmeyiniz.")]
        public string AdSoyad { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MaxLength(16, ErrorMessage = "Lütfen 16 karakterden fazla değer girmeyiniz.")]
        public string Sifre { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; }

        [Display(Name = "Aktif")]
        public bool Aktif { get; set; }

        public virtual Rol Rol { get; set; }
    }
}