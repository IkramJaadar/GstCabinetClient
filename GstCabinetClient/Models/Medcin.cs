using System.ComponentModel.DataAnnotations;

namespace GstCabinetClient.Models
{
    public class Medcin
    {
        [Key]
        public int Id { get; set; }
        public string ?Nom { get; set; }
        public string ?Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string ?Email { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? Ville { get; set;}
        public string? Specialité { get; set; }
        public List<RendezVous>?rendezVous { get; set; }
        public List<Disponibilite>?disponibilites { get; set; }  



    }
}
