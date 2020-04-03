using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;
using RecipeWebsite.Models.CookbookViewModels;

namespace RecipeWebsite.Pages.MealTypes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public IndexModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        //public IList<MealType> MealType { get;set; }
        public MealTypeIndexData MealTypeData { get; set; }
        public int MealTypeID { get; set; }
        public int RecipeID { get; set; }

        public async Task OnGetAsync(int? id, int? recipeID)
        {
            //MealType = await _context.MealTypes.ToListAsync();
            MealTypeData = new MealTypeIndexData();
            MealTypeData.MealTypes = await _context.MealTypes
                .Include(m => m.RecipeAssignments)
                    .ThenInclude(m => m.Recipe)
                /*.Include(m => m.RecipeAssignments)
                    .ThenInclude(m => m.Recipe)
                        .ThenInclude(m => m.QuantityInRecipes)
                            .ThenInclude(m => m.Ingredient)
                .AsNoTracking()*/
                .OrderBy(m => m.ID)
                .ToListAsync();

            if (id != null)
            {
                MealTypeID = id.Value;
                MealType mealtype = MealTypeData.MealTypes
                    .Where(m => m.ID == id.Value).Single();
                MealTypeData.Recipes = mealtype.RecipeAssignments.Select(i => i.Recipe);
            }

            if (recipeID != null)
            {
                RecipeID = recipeID.Value;
                var selectedRecipe = MealTypeData.Recipes
                    .Where(r => r.RecipeID == recipeID).Single();
                await _context.Entry(selectedRecipe).Collection(r => r.QuantityInRecipes).LoadAsync();
                foreach (QuantityInRecipe quantityInRecipe in selectedRecipe.QuantityInRecipes)
                {
                    await _context.Entry(quantityInRecipe).Reference(q => q.Ingredient).LoadAsync();
                }
                MealTypeData.QuantityInRecipes = selectedRecipe.QuantityInRecipes;
            }
        }
    }
}
