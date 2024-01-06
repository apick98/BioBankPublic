using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Collections
{
    public class CreateModel : PageModel
    {
        private readonly BioBank.Data.BioBankContext _context;

        public CreateModel(BioBank.Data.BioBankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Collection Collection { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Collections.Add(Collection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
