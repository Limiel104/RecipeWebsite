using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.MealTypes
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public DetailsModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public MealType MealType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MealType = await _context.MealTypes.FirstOrDefaultAsync(m => m.ID == id);

            if (MealType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
