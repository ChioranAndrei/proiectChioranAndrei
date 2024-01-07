using proiectChioranAndrei.Models.ViewModels;

namespace proiectChioranAndrei.Models
{
    public class CardTuristic
    {

        public int ID { get; set; }
        public string NumeOras { get; set; }
        public ICollection<ObiectivInclus>? ObiectivInclus { get; set; }
        public int? TaraID { get; set; }


    }
}
