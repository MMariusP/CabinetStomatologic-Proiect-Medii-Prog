using System.ComponentModel.DataAnnotations;

namespace CabinetStomatologic.Models
{
    public class Cabinet
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Numarul Cabinetului")]
        public int NumarSala { get; set; }

        [Required]
        [Display(Name = "Etaj")]
        public int Etaj { get; set; }
    }
}
