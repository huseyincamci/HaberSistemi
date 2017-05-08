using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberiSistemi.Data.Model
{
    [Table("Kullanici")]
    public class Kullanici : BaseEntity
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        [MaxLength(20, ErrorMessage = "Lütfen 20 karakterden fazla değer girmeyiniz.")]
        public string KullaniciAdi { get; set; }

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

        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}