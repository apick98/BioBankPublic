using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BioBank.Data;
using BioBank.Models;
using Microsoft.Extensions.Configuration;

namespace BioBank.Pages.Collections
{
    public class IndexModel : PageModel
    {
        private readonly BioBankContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(BioBankContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string DiseaseTermSort { get; set; }
        public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Collection> Collections { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;


            DiseaseTermSort = String.IsNullOrEmpty(sortOrder) ? "term_desc" : "";
            TitleSort = sortOrder == "Title" ? "title_desc" : "Title";


            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            CurrentFilter = searchString;

            IQueryable<Collection> collectionsIQ = from s in _context.Collections
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                collectionsIQ = collectionsIQ.Where(s => s.DiseaseTerm.ToUpper().Contains(searchString.ToUpper())
                                       || s.Title.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "term_desc":
                    collectionsIQ = collectionsIQ.OrderByDescending(s => s.DiseaseTerm);
                    break;
                case "Title":
                    collectionsIQ = collectionsIQ.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    collectionsIQ = collectionsIQ.OrderByDescending(s => s.Title);
                    break;
                default:
                    collectionsIQ = collectionsIQ.OrderBy(s => s.DiseaseTerm);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Collections = await PaginatedList<Collection>.CreateAsync(
                collectionsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
