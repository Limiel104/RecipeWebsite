using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models.CookbookViewModels
{
    public class MealTypeIndexData
    {
        public IEnumerable<MealType> MealTypes { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
        public IEnumerable<QuantityInRecipe> QuantityInRecipes { get; set; }
    }
}
