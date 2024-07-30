using System.ComponentModel.DataAnnotations;

namespace Hikayematik.Models
{
    public class Pratik_Bilgiler
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Başlık")]

        public string? Baslik { get; set; } = string.Empty;
        [Display(Name = "İçerik")]

        public string? Icerik { get; set; }
    }
}
