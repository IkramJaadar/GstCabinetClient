namespace GstCabinetClient.Models
{
    public class Disponibilite
    {
     
        public int Id { get; set; }
        public DateTime DateRendezvous { get; set; }
        public TimeSpan? Horraire { get; set; }
        public Medcin? Medcin { get; set; }
        public int? MedcinID { get; set; }
    }
}
