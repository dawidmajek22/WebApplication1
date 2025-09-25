using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class HodowlaAdres
    {
        [Key]
        public int Id { get; set; }
        public int HodowlaId { get; set; }
        public int AdresId { get; set; }

        public Hodowla? Hodowla { get; set; }
        public Adres? Adres { get; set; }
    }

}
