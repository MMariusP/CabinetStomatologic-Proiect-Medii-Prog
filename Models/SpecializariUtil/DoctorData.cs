using CabinetStomatologic.Migrations;

namespace CabinetStomatologic.Models.SpecializariUtil
{
    public class DoctorData
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Specializare> Specializari { get; set; }
        public IEnumerable<SpecializariDoctor> SpecializariDoctori { get; set; }
    }
}
