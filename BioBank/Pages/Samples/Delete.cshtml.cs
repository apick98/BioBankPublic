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
    public class DeleteModel : PageModel
    {
        private readonly BioBank.Data.BioBankContext _context;

        public DeleteModel(BioBank.Data.BioBankContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            Sample = await _context.Samples.FindAsync(id);
            if (Sample != null)
            {
                var collectionId = Sample.CollectionID;

                var collection = await _context.Collections.FindAsync(collectionId);
                if (collection != null)
                {
                    collection.Samples.Remove(Sample);
                }

                _context.Samples.Remove(Sample);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Collections/Details", new { id = collectionId });
            }

            return RedirectToPage("/Collections/Details", new { id = CollectionID });
        }
    }
}
