﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetStomatologic.Data;
using CabinetStomatologic.Models;

namespace CabinetStomatologic.Pages.Doctori
{
    public class DeleteModel : PageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public DeleteModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
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

            var doctor = await _context.Doctor.FirstOrDefaultAsync(m => m.ID == id);

            if (doctor == null)
            {
                return NotFound();
            }
            else 
            {
                Doctor = doctor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }
            var doctor = await _context.Doctor.FindAsync(id);

            if (doctor != null)
            {
                Doctor = doctor;
                _context.Doctor.Remove(Doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
