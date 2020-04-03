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
    public class DeleteModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public DeleteModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MealType = await _context.MealTypes.FindAsync(id);

            if (MealType != null)
            {
                _context.MealTypes.Remove(MealType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
