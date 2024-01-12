namespace CabinetStomatologic.Models.SpecializariUtil
{
    public class SpecializariDoctor
    {
        public int ID { get; set; }
        public int SpecializareID { get; set; }
        public Specializare Specializare { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
    }
}
