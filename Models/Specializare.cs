using System.ComponentModel.DataAnnotations;
using CabinetStomatologic.Models.SpecializariUtil;

namespace CabinetStomatologic.Models
{
    public class Specializare
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Denumire Specializare")]
        public string NumeSpecializare { get; set; }

        public ICollection<SpecializariDoctor>? SpecializariDoctori { get; set; }

    }
}
