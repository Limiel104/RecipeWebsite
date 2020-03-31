using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.QuantityInRecipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public IndexModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public IList<QuantityInRecipe> QuantityInRecipe { get;set; }

        public async Task OnGetAsync()
        {
            QuantityInRecipe = await _context.QuantityInRecipes
                .Include(q => q.Ingredient)
                .Include(q => q.Recipe).ToListAsync();
        }
    }
}
