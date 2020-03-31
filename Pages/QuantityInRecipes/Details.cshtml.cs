using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.QuantityInRecipes
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public DetailsModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public QuantityInRecipe QuantityInRecipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuantityInRecipe = await _context.QuantityInRecipes
                .Include(q => q.Ingredient)
                .Include(q => q.Recipe).FirstOrDefaultAsync(m => m.QuantityInRecipeID == id);

            if (QuantityInRecipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
