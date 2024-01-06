using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Collections
{
    public class DetailsModel : PageModel
    {
        private readonly BioBank.Data.BioBankContext _context;

        public DetailsModel(BioBank.Data.BioBankContext context)
        {
            _context = context;
        }

        public Collection Collection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections
            .Include(s => s.Samples)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (collection == null)
            {
                return NotFound();
            }
            else
            {
                Collection = collection;
            }
            return Page();
        }
    }
}
