using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BioBank.Models;

namespace BioBank.Pages.Samples
{
    public class DetailsModel : PageModel
    {
        private readonly Data.BioBankContext _context;

        public DetailsModel(Data.BioBankContext context)
        {
            _context = context;
        }

        public Sample Sample { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int CollectionID { get; set; }

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
                CollectionID = Sample.CollectionID;
            }
            return Page();
        }
    }
}
