using System.ComponentModel.DataAnnotations;

namespace CabinetStomatologic.Models
{
    public class Cabinet
    {
        public int ID { get; set; }
        [Display(Name = "Numarul Cabinetului")]
        public int NumarSala { get; set; }
        [Display(Name = "Etaj")]
        public int Etaj { get; set; }
    }
}
