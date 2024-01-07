using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Samples
{
    public class EditModel : PageModel
    {
        private readonly BioBank.Data.BioBankContext _context;

        public EditModel(BioBank.Data.BioBankContext context)
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

            var sample =  await _context.Samples.FirstOrDefaultAsync(m => m.SampleID == id);
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(Sample.SampleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SampleExists(int id)
        {
            return _context.Samples.Any(e => e.SampleID == id);
        }
    }
}
