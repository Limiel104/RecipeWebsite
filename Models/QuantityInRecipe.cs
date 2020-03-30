using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class QuantityInRecipe
    {
        public int QuantityInRecipeID { get; set; }
        public int IngredientID { get; set; }
        public int RecipeID { get; set; }
        public string Quantity { get; set; }


        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }


    }
}
