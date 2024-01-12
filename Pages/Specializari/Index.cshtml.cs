using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetStomatologic.Data;
using CabinetStomatologic.Models;

namespace CabinetStomatologic.Pages.Specializari
{
    public class IndexModel : PageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public IndexModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
        {
            _context = context;
        }

        public IList<Specializare> Specializare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Specializare != null)
            {
                Specializare = await _context.Specializare.ToListAsync();
            }
        }
    }
}
