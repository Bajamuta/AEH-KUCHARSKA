﻿using System;
using System.Collections.Generic;

namespace KsiazkaKucharskaConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            //dataAccess.AddAuthor("admin", "Lidia Figowska", "figa", "90fi6a", "Potrawy azjatyckie nie mają przed nią tajemnic");
            List<Author> authors = dataAccess.GetAuthors();
            // TODO why skipping first record?
            foreach (var author in authors) 
            {
                Console.WriteLine("The author " + author.name + ", type: " + author.type + ", login: " + author.login + ", description: " + author.description);
            }
            //dataAccess.AddRecipe("Salad", "https://facebook.com", 3);
            List<Recipe> recipes = dataAccess.GetRecipes();
            foreach (var recipe in recipes) 
            {
                Console.WriteLine("The recipe " + recipe.name + ", author: " + recipe.id_author);
            }
            //dataAccess.AddCategory("italy", "Italian recipes");
            //dataAccess.AddCategory("spain", "Spanish recipes");
            List<Category> categories = dataAccess.GetCategories();
            foreach (var category in categories) 
            {
                Console.WriteLine("The category " + category.name + ", description: " + category.description);
            }
            //dataAccess.AddIngridient("potatoe", "gramm");
            //dataAccess.AddIngridient("onion", "gramm");
            List<Ingridient> ingridients = dataAccess.GetIngridients();
            foreach (var ingridient in ingridients) 
            {
                Console.WriteLine("The ingridient " + ingridient.name + ", junit: " + ingridient.junit);
            }
            //dataAccess.AddStep("chop vegetables");
            //dataAccess.AddStep("boil");
            List<Step> steps = dataAccess.GetSteps();
            foreach (var step in steps) 
            {
                Console.WriteLine("The step: " + step.description);
            }
            //dataAccess.AddIngridientsList(1,12,3);
            //dataAccess.AddIngridientsList(1,25,2);
            List<IngridientsList> ingridientsLists = dataAccess.GetIngridientsLists();
            foreach (var list in ingridientsLists) 
            {
                Console.WriteLine("The ingridients list: " + list.id_ingridients_list + ", id ingridient: " + list.id_ingridient + ", countity: " + list.countity + ", id recipe:" + list.id_recipe);
            }
            /*dataAccess.AddBook("Test Book", 1);
            foreach (var book in dataAccess.GetBooks()) 
            {
                Console.WriteLine("hello");

                Console.WriteLine("The book '" + book.name + ", id of recipes list: " + book.id_recipes_list);
            }*/
        }
    }
}