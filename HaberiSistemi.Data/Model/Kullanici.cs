using System.ComponentModel.DataAnnotations;

namespace HaberiSistemi.Data.Model
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
    }
}