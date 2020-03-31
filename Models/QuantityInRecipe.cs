using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class QuantityInRecipe
    {
        public int QuantityInRecipeID { get; set; }

        [Display(Name = "Składnik")]
        public int IngredientID { get; set; }

        [Display(Name = "Przepis")]
        public int RecipeID { get; set; }

        [Display(Name = "Ilość")]
        public string Quantity { get; set; }



        [Display(Name = "Składnik")]
        public Ingredient Ingredient { get; set; }

        [Display(Name = "Przepis")]
        public Recipe Recipe { get; set; }


    }
}
