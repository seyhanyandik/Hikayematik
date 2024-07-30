using System.ComponentModel.DataAnnotations;

namespace Hikayematik.Models
{
    public class Siir
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        public string? Baslik { get; set; } = string.Empty;
        [Display(Name = "Şair")]
        public string? Sair { get; set; }

        [Display(Name = "İçerik")]
        public string? Icerik { get; set; }
        [Display(Name = "Yayım Tarihi")]
        public DateTime? yayim_tarihi { get; set; }


    }
}
