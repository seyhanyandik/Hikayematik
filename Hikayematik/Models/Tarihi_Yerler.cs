using System.ComponentModel.DataAnnotations;

namespace Hikayematik.Models
{
    public class Tarihi_Yerler
    {
        [Key]
        public int Id { get; set; }

        public string? Ad { get; set; }

        public string? Lokasyon { get; set; }
        [Display(Name = "Tarihçe")]

        public string? Tarihce { get; set; }
    }
}
