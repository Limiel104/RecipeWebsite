using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Models;

namespace RecipeWebsite.Data
{
    public class CookbookContext : DbContext
    {
        public CookbookContext (DbContextOptions<CookbookContext> options)
            : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<QuantityInRecipe> QuantityInRecipes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<QuantityInRecipe>().ToTable("QuantityInRecipe");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        }
    }
}
