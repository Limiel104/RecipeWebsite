using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public enum TypeOfFood
    {
        drób, makarony, nabiał, oleje, orzechy, owoce, pieczywo, przyprawy, ryby, warzywa, wieprzowina, zboża,
    }

    public class Ingredient
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Typ")]
        public TypeOfFood? TypeOfFood { get; set; } // ? means it's nullable

        public ICollection<QuantityInRecipe> QuantityInRecipes { get; set; }
    }
}
