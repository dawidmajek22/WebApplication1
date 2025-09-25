using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }
        public string TypAdresu { get; set; } = "formalny";
        public string? Panstwo { get; set; }
        public string? Miejscowosc { get; set; }
        public string? Ulica { get; set; }
        public string? KodPocztowy { get; set; }
        public string? Email { get; set; }
        public string? Www { get; set; }
        public string? TelStacjonarny { get; set; }
        public string? TelKomorkowy { get; set; }

        public List<HodowlaAdres> HodowlaAdresy { get; set; } = new();
    }

}
