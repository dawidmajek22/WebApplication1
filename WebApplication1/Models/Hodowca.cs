using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Hodowca
    {
        [Key]
        public int IdHodowcy { get; set; }
        [Required]
        public string Imie { get; set; } = string.Empty;
        [Required]
        public string Nazwisko { get; set; } = string.Empty;


    }
}
