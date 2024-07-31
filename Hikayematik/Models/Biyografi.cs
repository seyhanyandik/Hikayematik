using System.ComponentModel.DataAnnotations;

namespace Hikayematik.Models
{
    public class Biyografi
    {
        [Key]
        public int Id { get; set; }

        public string? Ad { get; set; } = string.Empty;
        [Display(Name = "Doğum Tarihi")]

        public DateTime? dogum_tarihi { get; set; }
        [Display(Name = "Ölüm Tarihi")]

        public DateTime? olum_tarihi { get; set; } 

        public string? Meslek { get; set; } = string.Empty;
        [Display(Name = "Biyografi")]

        public string? biyografi { get; set; } = string.Empty;

    }
}
