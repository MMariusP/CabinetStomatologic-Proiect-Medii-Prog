using System.ComponentModel.DataAnnotations;

namespace CabinetStomatologic.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataProgramare { get; set; }   
    }
}
