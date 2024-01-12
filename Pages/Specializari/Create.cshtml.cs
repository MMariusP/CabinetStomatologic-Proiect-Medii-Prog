using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CabinetStomatologic.Data;
using CabinetStomatologic.Models;

namespace CabinetStomatologic.Pages.Specializari
{
    public class CreateModel : PageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public CreateModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Specializare Specializare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Specializare == null || Specializare == null)
            {
                return Page();
            }

            _context.Specializare.Add(Specializare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
