using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BioBank.Models;

namespace BioBank.Pages.Collections
{
    public class CreateModel : PageModel
    {
        private readonly Data.BioBankContext _context;

        public CreateModel(Data.BioBankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCollection = new Collection { DiseaseTerm = string.Empty, Title = string.Empty};

            if (await TryUpdateModelAsync<Collection>(
                emptyCollection,
                "collection",
                s => s.DiseaseTerm, s => s.Title))
            {
                _context.Collections.Add(emptyCollection);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
