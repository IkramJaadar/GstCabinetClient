using GstCabinetClient.Models;
using System.ComponentModel.DataAnnotations;

namespace GstCabinetClient.Models
{
    public class RendezVous
    {
        [Key]
        public int Num { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public TimeSpan ?Horraire { get; set; }
     //   public string? Etat { get; set; }
        public Medcin ?Medcin { get; set; }
        public int ?MedcinID { get; set; }
        public Patient? Patient { get; set; }
        public int ?PatientID { get; set; }


    }
}
