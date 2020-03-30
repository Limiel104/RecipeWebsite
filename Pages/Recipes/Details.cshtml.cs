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
    public class DetailsModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public DetailsModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes
                .Include(r => r.QuantityInRecipes)
                .ThenInclude(q => q.Ingredient)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
