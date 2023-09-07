using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GstCabinetClient.Models
{
    public class Patient
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string ?Sexe { get; set; }
        public DateTime ?DateNaissance { get; set; }
        public List<RendezVous>? rendezVous { get; set; }


    }
}
