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
    public class IndexModel : PageModel
    {
        private readonly BioBankContext _context;
        public IndexModel(BioBankContext context)
        {
            _context = context;
        }

        public string DiseaseTermSort { get; set; }
        public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Collection> Collections { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            DiseaseTermSort = String.IsNullOrEmpty(sortOrder) ? "term_desc" : "";
            TitleSort = sortOrder == "Title" ? "title_desc" : "Title";

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

            Collections = await collectionsIQ.AsNoTracking().ToListAsync();
        }
    }
}
