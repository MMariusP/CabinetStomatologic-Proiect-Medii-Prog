using System.ComponentModel.DataAnnotations;

namespace CabinetStomatologic.Models
{
    public class Specializare
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Denumire Specializare")]
        public string NumeSpecializare { get; set; }
    }
}
