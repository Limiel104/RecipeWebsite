using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models.CookbookViewModels
{
    public class AssignedMealTypeData
    {
        public int MealTypeID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
