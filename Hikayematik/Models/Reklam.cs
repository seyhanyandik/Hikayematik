using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hikayematik.Models
{
    public class Reklam
    {
        [Key]
        public int ReklamId { get; set; }
        
        public string? Ad { get; set; }

        public string? Baslik1 { get; set; }

        public string? Baslik2 { get; set; }

        public string? Icerik { get; set; }

        public string? ReklamResim { get; set; }
        [NotMapped]

        public IFormFile? ResimYukle { get; set; }


    }
}
