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
    public class IndexModel : PageModel
    {
        private readonly CabinetStomatologic.Data.CabinetStomatologicContext _context;

        public IndexModel(CabinetStomatologic.Data.CabinetStomatologicContext context)
        {
            _context = context;
        }

        public IList<Cabinet> Cabinet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cabinet != null)
            {
                Cabinet = await _context.Cabinet.ToListAsync();
            }
        }
    }
}
