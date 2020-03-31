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

namespace RecipeWebsite.Pages.QuantityInRecipes
{
    public class EditModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public EditModel(RecipeWebsite.Data.CookbookContext context)
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

            var ingredientsQuery = from i in _context.Ingredients
                                   orderby i.Name
                                   select i;

            var recipesQuery = from r in _context.Recipes
                               orderby r.Name
                               select r;

            ViewData["IngredientID"] = new SelectList(ingredientsQuery, "ID", "Name");
            ViewData["RecipeID"] = new SelectList(recipesQuery, "RecipeID", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(QuantityInRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityInRecipeExists(QuantityInRecipe.QuantityInRecipeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuantityInRecipeExists(int id)
        {
            return _context.QuantityInRecipes.Any(e => e.QuantityInRecipeID == id);
        }
    }
}
