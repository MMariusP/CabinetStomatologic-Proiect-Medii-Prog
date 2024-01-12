using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabinetStomatologic.Data;
using CabinetStomatologic.Models;
using CabinetStomatologic.Models.SpecializariUtil;

namespace CabinetStomatologic.Pages.Doctori
{
    public class EditModel : SpecializariDoctoriPageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public EditModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor =  await _context.Doctor
                .Include( d => d.SpecializariDoctor).ThenInclude(b => b.Specializare)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (doctor == null)
            {
                return NotFound();
            }

            PopulateAssignedSpecializariData(_context, doctor);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] specializariSelectate)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doctorToUpdate = await _context.Doctor
            .Include(i => i.SpecializariDoctor)
            .ThenInclude(i => i.Specializare)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (doctorToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Doctor>(doctorToUpdate, "Doctor",
                i => i.Titulatura, i => i.Nume, i => i.Prenume, i => i.TelefonMobil, i => i.Email))
            {
                UpdateBookCategories(_context, specializariSelectate, doctorToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateBookCategories(_context, specializariSelectate, doctorToUpdate);
            PopulateAssignedSpecializariData(_context, doctorToUpdate);
            return Page();
        }

        private bool DoctorExists(int id)
        {
          return (_context.Doctor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
