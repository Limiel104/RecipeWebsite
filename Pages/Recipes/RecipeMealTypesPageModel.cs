using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeWebsite.Data;
using RecipeWebsite.Models;
using RecipeWebsite.Models.CookbookViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RecipeWebsite.Pages.Recipes
{
    public class RecipeMealTypesPageModel : PageModel
    {
        public List<AssignedMealTypeData> AssignedMealTypeDataList;

        public void PopulateAssignedMealTypeData(CookbookContext context,Recipe recipe)
        {
            var allMealTypes = context.MealTypes;
            var recipeMealTypes = new HashSet<int>(
                recipe.RecipeAssignments.Select(m => m.MealTypeID));
            AssignedMealTypeDataList = new List<AssignedMealTypeData>();
            foreach (var mealType in allMealTypes)
            {
                AssignedMealTypeDataList.Add(new AssignedMealTypeData
                {
                    MealTypeID = mealType.ID,
                    Name = mealType.Name,
                    Assigned = recipeMealTypes.Contains(mealType.ID)
                });
            }
        }

        public void UpdateRecipeMealTypes(CookbookContext context, string[] selectedMealTypes, Recipe recipeToUpdate)
        {
            if (selectedMealTypes == null)
            {
                recipeToUpdate.RecipeAssignments = new List<RecipeAssignment>();
                return;
            }

            var selectedMealTypesHS = new HashSet<string>(selectedMealTypes);
            var recipeMealTypes = new HashSet<int>(recipeToUpdate.RecipeAssignments.Select(r => r.Recipe.RecipeID));
            foreach (var mealType in context.MealTypes)
            {
                if (!selectedMealTypesHS.Contains(mealType.ID.ToString()))
                {
                    if (!recipeMealTypes.Contains(mealType.ID))
                    {
                        recipeToUpdate.RecipeAssignments.Add(
                            new RecipeAssignment
                            {
                                RecipeID = recipeToUpdate.RecipeID,
                                MealTypeID = mealType.ID
                            });
                    }
                }
                else
                {
                    if (recipeMealTypes.Contains(mealType.ID))
                    {
                        RecipeAssignment mealToRemove = recipeToUpdate
                            .RecipeAssignments
                            .SingleOrDefault(r => r.MealTypeID == mealType.ID);
                        context.Remove(mealToRemove);
                    }
                }
            }
        }
    }
}
