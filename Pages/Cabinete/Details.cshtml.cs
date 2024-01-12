using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetStomatologic.Data;
using CabinetStomatologic.Models;

namespace CabinetStomatologic.Pages.Cabinete
{
    public class DetailsModel : PageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public DetailsModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
        {
            _context = context;
        }

      public Cabinet Cabinet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cabinet == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinet.FirstOrDefaultAsync(m => m.ID == id);
            if (cabinet == null)
            {
                return NotFound();
            }
            else 
            {
                Cabinet = cabinet;
            }
            return Page();
        }
    }
}
