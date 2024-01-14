using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetStomatologic.Data;
using CabinetStomatologic.Models;
using CabinetStomatologic.Models.SpecializariUtil;
using System.Net;

namespace CabinetStomatologic.Pages.Doctori
{
    public class IndexModel : PageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public IndexModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; } = default!;
        public DoctorData DoctorD { get; set; }
        public int DoctorID { get; set; }
        public int SpecializareID { get; set; }

        public async Task OnGetAsync(int? id, int? specializareID)
        {

            DoctorD = new DoctorData();

            DoctorD.Doctors = await _context.Doctor
            .Include(b => b.SpecializariDoctor)
            .ThenInclude(b => b.Specializare)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (id != null)
            {
                DoctorID = id.Value;
                Doctor doctor = DoctorD.Doctors
                .Where(i => i.ID == id.Value).Single();
                DoctorD.Specializari = doctor.SpecializariDoctor.Select(s => s.Specializare);
            }

        }
    }
}
