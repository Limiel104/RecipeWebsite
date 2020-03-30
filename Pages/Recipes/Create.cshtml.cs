using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Recipes
{
    public class CreateModel : PageModel
    {
        private readonly RecipeWebsite.Data.CookbookContext _context;

        public CreateModel(RecipeWebsite.Data.CookbookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RecipeVM RecipeVM { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Recipe());
            entry.CurrentValues.SetValues(RecipeVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
