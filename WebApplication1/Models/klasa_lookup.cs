using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class klasa_lookup
    {
        [Key]
        public int KLASA_ID { get; set; }
        public string? NAZWA { get; set; }
        public string? OD_ILE_MIESIECY { get; set; }
        public string? DO_ILE_MIESIECY { get; set; }
        public string? TYP_OCENY { get; set; }
    }
}
