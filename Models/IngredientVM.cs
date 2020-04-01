using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class IngredientVM
    {
        public int ID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Typ")]
        public TypeOfFood? TypeOfFood { get; set; } // ? means it's nullable
    }
}
