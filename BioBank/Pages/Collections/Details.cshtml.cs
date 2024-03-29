using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BioBank.Data;
using BioBank.Models;

namespace BioBank.Pages.Collections
{
    public class DetailsModel : PageModel
    {
        private readonly BioBankContext _context;
        private readonly IConfiguration Configuration;

        public DetailsModel(BioBankContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public Collection Collection { get; set; } = default!;
        public string DonorCountSort { get; set; }
        public string MaterialTypeSort { get; set; }
        public string LastUpdatedSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Sample> Samples {get; set;}

        public async Task OnGetAsync(string sortOrder, int? id, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            DonorCountSort = String.IsNullOrEmpty(sortOrder) ? "donorCount_desc" : "";
            MaterialTypeSort = sortOrder == "MaterialType" ? "materialType_desc" : "MaterialType";
            LastUpdatedSort = sortOrder == "LastUpdated" ? "lastUpdated_desc" : "LastUpdated";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;


            var collection = await _context.Collections
            .Include(s => s.Samples)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (collection != null)
            {
                Collection = collection;

                if (Collection.Samples == null)
                {
                    Collection.Samples = new List<Sample>();
                }

                IQueryable<Sample> samplesIQ = _context.Samples.Where(s => s.CollectionID == id);

                if (!String.IsNullOrEmpty(searchString))
                {
                    samplesIQ = samplesIQ.Where(s => s.MaterialType.ToUpper().Contains(searchString.ToUpper()));
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
                var pageSize = Configuration.GetValue("PageSize", 4);
                Samples = await PaginatedList<Sample>.CreateAsync(
                    samplesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
    }
}
