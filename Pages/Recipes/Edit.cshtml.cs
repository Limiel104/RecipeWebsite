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

namespace RecipeWebsite.Pages.Recipes
{
    public class EditModel : RecipeMealTypesPageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public EditModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Recipe = await _context.Recipes.FindAsync(id);
            Recipe = await _context.Recipes
                .Include(r => r.RecipeAssignments).ThenInclude(r => r.MealType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.RecipeID == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            PopulateAssignedMealTypeData(_context,Recipe);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        //public async Task<IActionResult> OnPostAsync(int id)
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedMealTypes)
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(Recipe.RecipeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");*/

            /*bylo tylko to
             * var recipeToUpdate = await _context.Recipes.FindAsync(id);

            if (recipeToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Recipe>(
                recipeToUpdate,
                "recipe",
                r => r.Name, r => r.NumberOfServings, r => r.LastTimeServed))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();*/

            if (id == null)
            {
                return NotFound();
            }

            var recipeToUpdate = await _context.Recipes
                .Include(r => r.RecipeAssignments)
                    .ThenInclude(r => r.MealType)
                .FirstOrDefaultAsync(s => s.RecipeID == id);

            if (recipeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Recipe>(
                recipeToUpdate,
                "Recipe",
                r => r.Name, r => r.NumberOfServings, r => r.LastTimeServed))
            {
                UpdateRecipeMealTypes(_context,selectedMealTypes,recipeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateRecipeMealTypes(_context,selectedMealTypes,recipeToUpdate);
            PopulateAssignedMealTypeData(_context,recipeToUpdate);
            return Page();
        }

        /*private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeID == id);
        }*/
    }
}
