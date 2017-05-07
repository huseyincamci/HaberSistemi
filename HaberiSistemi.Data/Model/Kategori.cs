using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaberiSistemi.Data.Model
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "{0} karakterden az olamaz."), MaxLength(150, ErrorMessage = "150 karakterden fazla girmeyiniz.")]
        public string KategoriAdi { get; set; }

        public int ParentId { get; set; }

        [MinLength(2, ErrorMessage = "{0} karakterden az olamaz."), MaxLength(150, ErrorMessage = "150 karakterden fazla girmeyiniz.")]
        public string Url { get; set; }

        public bool Aktif { get; set; }

        public virtual ICollection<Haber> Habers { get; set; }
    }
}