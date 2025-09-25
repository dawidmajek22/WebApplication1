using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class HodowcaHodowlaView
    {
        [Key]
        public int IdHodowcy { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public int HodowlaId { get; set; }
        public string? Nazwa { get; set; }
        public string? Masc { get; set; }
    }
}