using System.ComponentModel.DataAnnotations;

namespace Hikayematik.Models
{
    public class Drama
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Başlık")]

        public string? Baslik { get; set; } = string.Empty;

        public string? Konu { get; set; } = string.Empty;
        [Display(Name = "İçerik")]

        public string? Icerik { get; set; }
        [Display(Name = "Yayım Tarihi")]

        public DateTime? yayim_tarihi { get; set; }

        public string Yazar { get; set; } = string.Empty;
    }
}
