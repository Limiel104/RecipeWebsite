using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class RecipeAssignment
    {
        public int MealTypeID { get; set; }
        public int RecipeID { get; set; }
        public MealType MealType { get; set; }
        public Recipe Recipe { get; set; }
    }
}
