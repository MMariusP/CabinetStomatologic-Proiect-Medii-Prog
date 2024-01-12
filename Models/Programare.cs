using System.ComponentModel.DataAnnotations;

namespace CabinetStomatologic.Models
{
    public class Programare
    {
        public int ID { get; set; }

        [Display(Name= "Nume Programare")]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name= "Data si Ora Programarii dumneavoastra")]
        public DateTime DataProgramare { get; set; }   
    }
}
