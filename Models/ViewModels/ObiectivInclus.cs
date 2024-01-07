namespace proiectChioranAndrei.Models.ViewModels
{
    public class ObiectivInclus
    {
        public int ID { get; set; }
        public int ObiectivTuristicID { get; set; }
        public ObiectivTuristic ObiectivTuristic { get; set; }
        public int CardTuristicID { get; set; }
        public CardTuristic CardTuristic{ get; set; }
    }
}
