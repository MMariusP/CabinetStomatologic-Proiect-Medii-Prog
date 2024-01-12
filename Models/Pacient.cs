using System.ComponentModel.DataAnnotations;

namespace CabinetStomatologic.Models
{
    public class Pacient
    {
        public int ID { get; set; }
        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Numarul de telefon nu este valid.")]
        [Display(Name = "Numarul de telefon")]
        public string TelefonMobil { get; set; }

        
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Adresa de email")]
        public string? Email { get; set; }

            
    }
}
