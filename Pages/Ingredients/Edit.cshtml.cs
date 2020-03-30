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
    public class EditModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public EditModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await _context.Ingredients.FindAsync(id);

            if (Ingredient == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(Ingredient.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");*/

            var ingredientToUpdate = await _context.Ingredients.FindAsync(id);

            if(ingredientToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Ingredient>(
                ingredientToUpdate,
                "ingredient",
                i => i.Name, i => i.TypeOfFood))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        /*
        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.ID == id);
        }*/
    }
}
