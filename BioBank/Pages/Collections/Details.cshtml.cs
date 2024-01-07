using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Collections
{
    public class DetailsModel : PageModel
    {
        private readonly BioBank.Data.BioBankContext _context;

        public DetailsModel(BioBank.Data.BioBankContext context)
        {
            _context = context;
        }

        public Collection Collection { get; set; } = default!;
        public string DonorCountSort { get; set; }
        public string MaterialTypeSort { get; set; }
        public string LastUpdatedSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task<IActionResult> OnGetAsync(string sortOrder, int? id, string searchString)
        {
            DonorCountSort = String.IsNullOrEmpty(sortOrder) ? "donorCount_desc" : "";
            MaterialTypeSort = sortOrder == "MaterialType" ? "materialType_desc" : "MaterialType";
            LastUpdatedSort = sortOrder == "LastUpdated" ? "lastUpdated_desc" : "LastUpdated";

            CurrentFilter = searchString;

            if (id == null)
            {
                return NotFound();
            }

            var collection = await _context.Collections
            .Include(s => s.Samples)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (collection == null)
            {
                return NotFound();
            }
            else
            {
                Collection = collection;
            }

            IQueryable<Sample> samplesIQ = collection.Samples.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                samplesIQ = samplesIQ.Where(s => s.MaterialType.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "donorCount_desc":
                    samplesIQ = samplesIQ.OrderByDescending(s => s.DonorCount);
                    break;
                case "MaterialType":
                    samplesIQ = samplesIQ.OrderBy(s => s.MaterialType);
                    break;
                case "materialType_desc":
                    samplesIQ = samplesIQ.OrderByDescending(s => s.MaterialType);
                    break;
                case "LastUpdated":
                    samplesIQ = samplesIQ.OrderBy(s => s.LastUpdated);
                    break;
                case "lastUpdated_desc":
                    samplesIQ = samplesIQ.OrderByDescending(s => s.LastUpdated);
                    break;
                default:
                    samplesIQ = samplesIQ.OrderBy(s => s.DonorCount);
                    break;
            }
            return Page();
        }
    }
}
