using CabinetStomatologic.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CabinetStomatologic.Models.SpecializariUtil
{
    public class SpecializariDoctoriPageModel : PageModel
    {
        public List<AssignedSpecializariData> AssignedSpecializariDataList;
        public void PopulateAssignedSpecializariData(CabinetStomatologicContext context,
        Doctor doctor)
        {
            var allSpecializari = context.Specializare;
            var specializarileDoctorului = new HashSet<int>(
            doctor.SpecializariDoctor.Select(c => c.SpecializareID)); //
            AssignedSpecializariDataList = new List<AssignedSpecializariData>();
            foreach (var cat in allSpecializari)
            {
                AssignedSpecializariDataList.Add(new AssignedSpecializariData
                {
                    SpecializareID = cat.ID,
                    Name = cat.NumeSpecializare,
                    Assigned = specializarileDoctorului.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(CabinetStomatologicContext context,
        string[] selectedCategories, Doctor doctorToUpdate)
        {
            if (selectedCategories == null)
            {
                doctorToUpdate.SpecializariDoctor = new List<SpecializariDoctor>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (doctorToUpdate.SpecializariDoctor.Select(c => c.Specializare.ID));
            foreach (var cat in context.Specializare)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        doctorToUpdate.SpecializariDoctor.Add(
                        new SpecializariDoctor
                        {
                            DoctorID = doctorToUpdate.ID,
                            SpecializareID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        SpecializariDoctor courseToRemove= doctorToUpdate
                        .SpecializariDoctor
                        .SingleOrDefault(i => i.SpecializareID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
