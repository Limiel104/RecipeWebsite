using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Ilość porcji")]
        public int NumberOfServings { get; set; }

        [DataType(DataType.Date)] //changes the way the date is displayed for all pages in the projct
        [Display(Name = "Data ostatniego użycia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastTimeServed { get; set; }

        public ICollection<QuantityInRecipe> QuantityInRecipes { get; set; }
    }
}
