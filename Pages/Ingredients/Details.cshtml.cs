using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Ingredients
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public DetailsModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public Ingredient Ingredient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await _context.Ingredients
                .Include(i => i.QuantityInRecipes)
                .ThenInclude(q => q.Recipe)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            /*Ingredient = await _context.Ingredients
                .Include(s => s.QuantityInRecipes)*/

            if (Ingredient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
