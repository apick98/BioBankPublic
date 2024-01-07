using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Samples
{
    public class EditModel : PageModel
    {
        private readonly BioBankContext _context;

        public EditModel(BioBankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sample Sample { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int CollectionID { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sample = await _context.Samples.FindAsync(id);

            if (Sample == null)
            {
                return NotFound();
            }
            else
            {
                CollectionID = Sample.CollectionID;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var sampleToUpdate = await _context.Samples.FindAsync(id);

            if (sampleToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                sampleToUpdate,
                "sample",
                s => s.DonorCount, s => s.MaterialType, s => s.LastUpdated))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("/Collections/Details", new { id = sampleToUpdate.CollectionID });
            }

            return RedirectToPage("/Collections/Details", new { id = CollectionID });
        }
    }
}