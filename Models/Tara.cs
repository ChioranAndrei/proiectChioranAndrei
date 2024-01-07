using System.ComponentModel.DataAnnotations;

namespace proiectChioranAndrei.Models
{
    public class Tara
    { public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s -]*$")]
        public string NumeTara { get; set; }
        public ICollection<Oras>? Orase{ get; set; }
    }
}
