using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class IngredientVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public TypeOfFood? TypeOfFood { get; set; } // ? means it's nullable
    }
}
