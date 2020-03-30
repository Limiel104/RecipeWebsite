using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Ingredients
{
    public class CreateModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public CreateModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IngredientVM IngredientVM { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ingredients.Add(Ingredient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/

            /*var emptyIngredient = new Ingredient();

            if (await TryUpdateModelAsync<Ingredient>(
                emptyIngredient,
                "ingredient",
                i => i.Name, i => i.TypeOfFood))
            {
                _context.Ingredients.Add(emptyIngredient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();*/

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Ingredient());
            entry.CurrentValues.SetValues(IngredientVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
