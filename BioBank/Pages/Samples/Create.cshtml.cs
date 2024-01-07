using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Samples
{
    public class CreateModel : PageModel
    {
        private readonly BioBankContext _context;

        public CreateModel(BioBankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sample Sample { get; set; } = default!;

        [BindProperty(SupportsGet = true)] 
        public int CollectionID { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Sample.CollectionID = CollectionID;

            Sample.LastUpdated = DateTime.Now;

            _context.Samples.Add(Sample);

            var collection = await _context.Collections.FindAsync(CollectionID);
            if (collection != null)
            {
                collection.Samples.Add(Sample);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/Collections/Details", new { id = Sample.CollectionID });
        }
    }
}
