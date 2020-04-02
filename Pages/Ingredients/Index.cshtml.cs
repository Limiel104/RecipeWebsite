using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public IndexModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Ingredient> Ingredients { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";

            CurrentFilter = searchString;

            IQueryable<Ingredient> ingredientIQ = from i in _context.Ingredients
                                                  select i;


            if (!String.IsNullOrEmpty(searchString))
            {
                ingredientIQ = ingredientIQ.Where(i => i.Name.Contains(searchString)
                                                    /*|| i.TypeOfFood.ToString().Contains(searchString)*/);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ingredientIQ = ingredientIQ.OrderByDescending(i => i.Name);
                    break;
                case "Type":
                    ingredientIQ = ingredientIQ.OrderBy(i => i.TypeOfFood);
                    break;
                case "type_desc":
                    ingredientIQ = ingredientIQ.OrderByDescending(i => i.TypeOfFood);
                    break;
                default:
                    ingredientIQ = ingredientIQ.OrderBy(i => i.Name);
                    break;
            }

            Ingredients = await ingredientIQ.AsNoTracking().ToListAsync();
        }
    }
}
