using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberiSistemi.Data.Model
{
    [Table("Rol")]
    public class Rol : BaseEntity
    {
        [Display(Name = "Rol Adı")]
        [MinLength(3, ErrorMessage = "Lütfen 3 karakterden fazla değer giriniz."), MaxLength(150, ErrorMessage = "Lütfen 150 karakterden fazla girmeyiniz.")]
        public string RolAdi { get; set; }
    }
}