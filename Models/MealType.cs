using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class MealType
    {
        public int ID { get; set; }

        [Display(Name = "Typ Dania")]
        public string Name { get; set; }

        public ICollection<RecipeAssignment> RecipeAssignments { get; set; }
    }
}
