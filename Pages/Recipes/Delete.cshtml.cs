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
    public class DeleteModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public DeleteModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (Recipe == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            Recipe = await _context.Recipes.FindAsync(id);

            if (Recipe != null)
            {
                _context.Recipes.Remove(Recipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");*/

            var recipe = await _context.Recipes.FindAsync(id);

            if(recipe == null)
            {
                return NotFound();
            }

            try
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch
            {
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
