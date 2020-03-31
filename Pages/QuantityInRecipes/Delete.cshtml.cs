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
    public class DeleteModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public DeleteModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            QuantityInRecipe = await _context.QuantityInRecipes.FindAsync(id);

            if (QuantityInRecipe != null)
            {
                _context.QuantityInRecipes.Remove(QuantityInRecipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
