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

namespace CabinetStomatologic.Pages.Cabinete
{
    public class EditModel : PageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public EditModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cabinet Cabinet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cabinet == null)
            {
                return NotFound();
            }

            var cabinet =  await _context.Cabinet.FirstOrDefaultAsync(m => m.ID == id);
            if (cabinet == null)
            {
                return NotFound();
            }
            Cabinet = cabinet;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cabinet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabinetExists(Cabinet.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CabinetExists(int id)
        {
          return (_context.Cabinet?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
