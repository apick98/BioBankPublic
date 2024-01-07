using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BioBank.Models;

namespace BioBank.Pages.Collections
{
    public class EditModel : PageModel
    {
        private readonly Data.BioBankContext _context;

        public EditModel(Data.BioBankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Collection = await _context.Collections.FindAsync(id);

            if (Collection == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var collectionToUpdate = await _context.Collections.FindAsync(id);

            if (collectionToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                collectionToUpdate,
                "collection",
                s => s.DiseaseTerm, s => s.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
