using System.ComponentModel.DataAnnotations;

namespace Hikayematik.Models
{
    public class Deyim_hikaye
    {
        [Key]
        public int Id { get; set; }

        public string? Deyim { get; set; }

        public string? Anlam { get; set; }
        [Display(Name = "Örnek")]

        public string? Ornek { get; set; }

    }
}
