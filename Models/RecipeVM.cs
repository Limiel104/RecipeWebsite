using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeWebsite.Models
{
    public class RecipeVM
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public int NumberOfServings { get; set; }
    }
}
