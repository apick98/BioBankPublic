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

        public async Task<IActionResult> OnGetAsync(string sortOrder, int? id)
        {
            DonorCountSort = String.IsNullOrEmpty(sortOrder) ? "donorCount_desc" : "";
            MaterialTypeSort = sortOrder == "MaterialType" ? "materialType_desc" : "MaterialType";
            LastUpdatedSort = sortOrder == "LastUpdated" ? "lastUpdated_desc" : "LastUpdated";

            

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

            switch (sortOrder)
            {
                case "donorCount_desc":
                    Collection.Samples = Collection.Samples.OrderByDescending(s => s.DonorCount).ToList();
                    break;
                case "MaterialType":
                    Collection.Samples = Collection.Samples.OrderBy(s => s.MaterialType).ToList();
                    break;
                case "materialType_desc":
                    Collection.Samples = Collection.Samples.OrderByDescending(s => s.MaterialType).ToList();
                    break;
                case "LastUpdated":
                    Collection.Samples = Collection.Samples.OrderBy(s => s.LastUpdated).ToList();
                    break;
                case "lastUpdated_desc":
                    Collection.Samples = Collection.Samples.OrderByDescending(s => s.LastUpdated).ToList();
                    break;
                default:
                    // Default sorting
                    Collection.Samples = Collection.Samples.OrderBy(s => s.DonorCount).ToList();
                    break;
            }
            return Page();
        }
    }
}
