using System.ComponentModel.DataAnnotations;

namespace proiectChioranAndrei.Models
{
    public class ObiectivTuristic
    {public int ID { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string Nume { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string Strada { get; set; }
        [Range(1,100)]
        public int Numar {  get; set; }
        [Range(1, 1000000000000)]
        public int Telefon { get; set; }
        public int? OrasID { get; set; }
        public Oras? Oras { get; set; }
    }
}
