using System.ComponentModel.DataAnnotations;

namespace proiectChioranAndrei.Models
{
    public class Oras
    {public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s -]*$")]
        public string NumeOras { get; set; }
        public ICollection<ObiectivTuristic>? ObiectivTuristic { get; set; }
        public int? TaraID {get ; set; }
         public Tara? Tara {get; set;}

    }
}
