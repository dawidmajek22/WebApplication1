using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication1.Models
{
    public class Hodowla
    {
        [Key]
        public int HodowlaId { get; set; }
        [Required]
        public string Nazwa { get; set; } = string.Empty;
        [Required]
        public string Masc { get; set; } = string.Empty;

        // Prawidłowy klucz obcy
        public int? IdHodowcy { get; set; }

        [ForeignKey(nameof(IdHodowcy))]
        public Hodowca? Hodowca { get; set; }

        public List<HodowlaAdres> HodowlaAdresy { get; set; } = new();
    }
}
