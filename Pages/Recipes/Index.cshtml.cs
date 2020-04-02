using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public IndexModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string ServingSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Recipe> Recipes { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //Recipe = await _context.Recipes.ToListAsync();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ServingSort = sortOrder == "Serving" ? "serving_desc" : "Serving";

            CurrentFilter = searchString;

            IQueryable<Recipe> recipesIQ = from r in _context.Recipes
                                           select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipesIQ = recipesIQ.Where(r => r.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.Name);
                    break;
                case "Date":
                    recipesIQ = recipesIQ.OrderBy(r => r.LastTimeServed);
                    break;
                case "date_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.LastTimeServed);
                    break;
                case "Serving":
                    recipesIQ = recipesIQ.OrderBy(r => r.NumberOfServings);
                    break;
                case "serving_desc":
                    recipesIQ = recipesIQ.OrderByDescending(r => r.NumberOfServings);
                    break;
                default:
                    recipesIQ = recipesIQ.OrderBy(r => r.Name);
                    break;
            }

            Recipes = await recipesIQ.AsNoTracking().ToListAsync();
        }
    }
}
