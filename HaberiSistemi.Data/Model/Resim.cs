﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HaberiSistemi.Data.Model
{
    [Table("Resim")]
    public class Resim
    {
        public int Id { get; set; }

        public string ResimUrl { get; set; }

        [ForeignKey("Haber")]
        public int HaberId { get; set; } 
        public Haber Haber { get; set; }    
    }
}