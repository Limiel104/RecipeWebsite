using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeWebsite.Data;
using RecipeWebsite.Models;

namespace RecipeWebsite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CookbookContext context)
        {
            context.Database.EnsureCreated();

            // Look for any ingredients.
            if (context.Ingredients.Any())
            {
                return;   // DB has been seeded
            }

            var ingredients = new Ingredient[]
            {
                new Ingredient{Name="Filet",TypeOfFood=TypeOfFood.drób},
                new Ingredient{Name="Penne",TypeOfFood=TypeOfFood.makarony},
                new Ingredient{Name="Śmietana 18%",TypeOfFood=TypeOfFood.nabiał},
                new Ingredient{Name="Szpinak",TypeOfFood=TypeOfFood.warzywa},
                new Ingredient{Name="Czosnek",TypeOfFood=TypeOfFood.warzywa},
                new Ingredient{Name="Masło",TypeOfFood=TypeOfFood.nabiał},
                new Ingredient{Name="Jajko"},
                new Ingredient{Name="Spaghetti",TypeOfFood=TypeOfFood.makarony},
                new Ingredient{Name="Jabłko",TypeOfFood=TypeOfFood.owoce},
                new Ingredient{Name="Ser Gouda",TypeOfFood=TypeOfFood.nabiał},
                new Ingredient{Name="Szynka"},
                new Ingredient{Name="Pomarańcza",TypeOfFood=TypeOfFood.owoce},
                new Ingredient{Name="Ser Mazur",TypeOfFood=TypeOfFood.nabiał}
            };
            foreach (Ingredient i in ingredients)
            {
                context.Ingredients.Add(i);
            }
            context.SaveChanges();

            var recipes = new Recipe[]
            {
                new Recipe{Name="Przepis1",NumberOfServings=1},
                new Recipe{Name="Przepis2",NumberOfServings=2},
                new Recipe{Name="Przepis3",NumberOfServings=3},
                new Recipe{Name="Przepis4",NumberOfServings=2}
            };
            foreach (Recipe r in recipes)
            {
                context.Recipes.Add(r);
            }
            context.SaveChanges();

            var quantityInRecipes = new QuantityInRecipe[]
            {
                new QuantityInRecipe{IngredientID=1,RecipeID=1,Quantity="10 ml"},
                new QuantityInRecipe{IngredientID=1,RecipeID=2,Quantity="5"},
                new QuantityInRecipe{IngredientID=2,RecipeID=3,Quantity="80 dag"},
                new QuantityInRecipe{IngredientID=2,RecipeID=2,Quantity="30 dag"},
                new QuantityInRecipe{IngredientID=2,RecipeID=4,Quantity="2"},
                new QuantityInRecipe{IngredientID=3,RecipeID=1,Quantity="50 ml"},
                new QuantityInRecipe{IngredientID=4,RecipeID=2,Quantity="6"},
                new QuantityInRecipe{IngredientID=4,RecipeID=3,Quantity="3"},
                new QuantityInRecipe{IngredientID=5,RecipeID=4,Quantity="50 dag"},
                new QuantityInRecipe{IngredientID=6,RecipeID=2,Quantity="3 kg"},
                new QuantityInRecipe{IngredientID=6,RecipeID=3,Quantity="6"},
                new QuantityInRecipe{IngredientID=6,RecipeID=1,Quantity="3"},
                new QuantityInRecipe{IngredientID=7,RecipeID=2,Quantity="20 dag"},
                new QuantityInRecipe{IngredientID=8,RecipeID=3,Quantity="5"},
                new QuantityInRecipe{IngredientID=9,RecipeID=2,Quantity="1"},
                new QuantityInRecipe{IngredientID=10,RecipeID=1,Quantity="70 ml"},
                new QuantityInRecipe{IngredientID=10,RecipeID=3,Quantity="20 ml"},
                new QuantityInRecipe{IngredientID=11,RecipeID=2,Quantity="2"},
                new QuantityInRecipe{IngredientID=11,RecipeID=4,Quantity="1"},
                new QuantityInRecipe{IngredientID=12,RecipeID=2,Quantity="8"},
                new QuantityInRecipe{IngredientID=13,RecipeID=4,Quantity="4 dag"},
                new QuantityInRecipe{IngredientID=13,RecipeID=1,Quantity="3"}
            };
            foreach (QuantityInRecipe q in quantityInRecipes)
            {
                context.QuantityInRecipes.Add(q);
            }
            context.SaveChanges();
        }
    }
}
