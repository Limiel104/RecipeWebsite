using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.QuantityInRecipes
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

        [BindProperty]
        public QuantityInRecipe QuantityInRecipe { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.QuantityInRecipes.Add(QuantityInRecipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
