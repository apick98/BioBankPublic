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
    public class IndexModel : PageModel
    {
        private readonly BioBank.Data.BioBankContext _context;

        public IndexModel(BioBank.Data.BioBankContext context)
        {
            _context = context;
        }

        public IList<Sample> Sample { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Sample = await _context.Samples.ToListAsync();
        }
    }
}
