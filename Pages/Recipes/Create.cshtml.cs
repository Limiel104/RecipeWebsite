using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Recipes
{
    public class CreateModel : RecipeMealTypesPageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public CreateModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //return Page();
            var recipe = new Recipe();
            recipe.RecipeAssignments = new List<RecipeAssignment>();
            PopulateAssignedMealTypeData(_context,recipe);
            return Page();
        }

        [BindProperty]
        public RecipeVM RecipeVM { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Recipe());
            entry.CurrentValues.SetValues(RecipeVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }*/

        public async Task<IActionResult> OnPostAsync(string[] selectedMealTypes)
        {
            var newRecipe = new Recipe();
            if (selectedMealTypes != null)
            {
                newRecipe.RecipeAssignments = new List<RecipeAssignment>();
                foreach (var mealType in selectedMealTypes)
                {
                    var mealTypeToAdd = new RecipeAssignment
                    {
                        MealTypeID = int.Parse(mealType)
                    };
                    newRecipe.RecipeAssignments.Add(mealTypeToAdd);
                }
            }

            if (await TryUpdateModelAsync<Recipe>(
                newRecipe,
                "Recipe",
                r => r.Name, r => r.NumberOfServings, r => r.LastTimeServed))
            {
                _context.Recipes.Add(newRecipe);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedMealTypeData(_context,newRecipe);
            return Page();
        }

    }
}
