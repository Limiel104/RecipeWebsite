using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public enum TypeOfFood
    {
        zboża,nabiał,orzechy,pieczywo,przyprawy,ryby,drób,wieprzowina,oleje,warzywa,owoce,makarony,
    }

    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TypeOfFood? TypeOfFood { get; set; } // ? means it's nullable

        public ICollection<QuantityInRecipe> QuantityInRecipes { get; set; }
    }
}
