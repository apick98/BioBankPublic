using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Samples
{
    public class DetailsModel : PageModel
    {
        private readonly BioBank.Data.BioBankContext _context;

        public DetailsModel(BioBank.Data.BioBankContext context)
        {
            _context = context;
        }

        public Sample Sample { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sample = await _context.Samples.FirstOrDefaultAsync(m => m.SampleID == id);
            if (sample == null)
            {
                return NotFound();
            }
            else
            {
                Sample = sample;
            }
            return Page();
        }
    }
}
