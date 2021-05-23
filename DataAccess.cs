using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace KsiazkaKucharskaConsole
{
    public class DataAccess
    {
      
        public List<Book> GetBooks(string name = "", int id_recipes = -1)
        {
            List<Book> books = new List<Book>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    connection.Open();
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //only name of book
                            if (name.Length > 0 && id_recipes < 0)
                            {
                                cmd.CommandText = "SELECT * FROM BOOK WHERE NAME = @name";
                                cmd.Parameters.Add(new SqlParameter("@name", name));
                            }
                            //name and id of recipes list
                            if (name.Length > 0 && id_recipes >= 0)
                            {
                                cmd.CommandText = "SELECT * FROM BOOK WHERE NAME = @name AND ID_RECIPES = @id_recipes";
                                cmd.Parameters.Add(new SqlParameter("@name", name));
                                cmd.Parameters.Add(new SqlParameter("@id_recipes", id_recipes));
                            }
                            //only id of recipes list
                            if (name.Length <= 0 && id_recipes >= 0)
                            {
                                cmd.CommandText = "SELECT * FROM BOOK WHERE ID_RECIPES = @id_recipes";
                                cmd.Parameters.Add(new SqlParameter("@id_recipes", id_recipes));
                            }
                            //all books
                            if (name.Length <= 0 && id_recipes < 0)
                            {
                                cmd.CommandText = "SELECT * FROM BOOK";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                books.Add(new Book(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return books;
        }

        public void AddBook(string name, int id_recipes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if(connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO BOOK VALUES (@id_recipes, @name)";
                            cmd.Parameters.Add(new SqlParameter("@name", name));
                            cmd.Parameters.Add(new SqlParameter("@id_recipes", id_recipes));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding book");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Recipe> GetRecipes(string name = "", int id_author = -1)
        {
            List<Recipe> recipes = new List<Recipe>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //all recipes
                            if (name.Length <= 0 && id_author <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM RECIPE";
                            }
                            // TODO using(rdr)
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                recipes.Add(
                                    new Recipe(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return recipes;
        }

        public void AddRecipe(string name, string photo, int id_author)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO RECIPE VALUES (@name, @photo, @id_author)";
                            cmd.Parameters.Add(new SqlParameter("@name", name));
                            cmd.Parameters.Add(new SqlParameter("@photo", photo));
                            cmd.Parameters.Add(new SqlParameter("@id_author", id_author));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding recipe");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Ingridient> GetIngridients(string name = "", string junit = "")
        {
            List<Ingridient> ingridients = new List<Ingridient>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //all recipes
                            if (name.Length <= 0 && junit.Length <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM INGRIDIENT";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                ingridients.Add(
                                    new Ingridient(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ingridients;
        }

        public void AddIngridient(string name, string junit)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO INGRIDIENT VALUES (@name, @junit)";
                            cmd.Parameters.Add(new SqlParameter("@name", name));
                            cmd.Parameters.Add(new SqlParameter("@junit", junit));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding ingridient");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Author> GetAuthors(string type = "", string login = "", string name = "")
        {
            List<Author> authors = new List<Author>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //only name of author
                            if (name.Length > 0 && type.Length <= 0 && login.Length <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM AUTHOR WHERE NAME LIKE @name";
                                cmd.Parameters.Add(new SqlParameter("@name", name));
                            }
                            //only login
                            if (name.Length <= 0 && type.Length <= 0 && login.Length > 0)
                            {
                                cmd.CommandText = "SELECT * FROM AUTHOR WHERE LOGIN LIKE @login";
                                cmd.Parameters.Add(new SqlParameter("@login", login));
                            }
                            //only type
                            if (name.Length <= 0 && type.Length > 0 && login.Length <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM AUTHOR WHERE TYPE LIKE @type";
                                cmd.Parameters.Add(new SqlParameter("@type", type));
                            }
                            //name and login
                            if (name.Length > 0 && type.Length <= 0 && login.Length > 0)
                            {
                                cmd.CommandText = "SELECT * FROM AUTHOR WHERE NAME LIKE @name AND LOGIN LIKE @login";
                                cmd.Parameters.Add(new SqlParameter("@name", name));
                                cmd.Parameters.Add(new SqlParameter("@login", login));
                            }
                            //name and type
                            if (name.Length > 0 && type.Length > 0 && login.Length <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM AUTHOR WHERE NAME LIKE @name AND TYPE LIKE @type";
                                cmd.Parameters.Add(new SqlParameter("@name", name));
                                cmd.Parameters.Add(new SqlParameter("@type", type));
                            }
                            //type and login
                            if (name.Length <= 0 && type.Length > 0 && login.Length > 0)
                            {
                                cmd.CommandText = "SELECT * FROM AUTHOR WHERE LOGIN LIKE @login AND TYPE LIKE @type";
                                cmd.Parameters.Add(new SqlParameter("@type", type));
                                cmd.Parameters.Add(new SqlParameter("@login", login));
                            }
                            //all authors
                            if (name.Length <= 0 && type.Length <= 0 && login.Length <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM AUTHOR";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                authors.Add(
                                    new Author(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return authors;
        }

        public void AddAuthor(string type, string name, string login, string password, string description)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO AUTHOR VALUES (@type, @name, @login, @password, @description)";
                            cmd.Parameters.Add(new SqlParameter("@type", type));
                            cmd.Parameters.Add(new SqlParameter("@name", name));
                            cmd.Parameters.Add(new SqlParameter("@login", login));
                            cmd.Parameters.Add(new SqlParameter("@password", password));
                            cmd.Parameters.Add(new SqlParameter("@description", description));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding author");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<Category> GetCategories(string name = "")
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //all category
                            if (name.Length <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM CATEGORY";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            { 
                                categories.Add(
                                    new Category(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return categories;
        }

        public void AddCategory(string name, string description)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO CATEGORY VALUES (@name, @description)";
                            cmd.Parameters.Add(new SqlParameter("@name", name));
                            cmd.Parameters.Add(new SqlParameter("@description", description));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding category");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<Step> GetSteps(string key = "")
        {
            List<Step> steps = new List<Step>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //all steps
                            if (key.Length <= 0)
                            {
                                cmd.CommandText = "SELECT * FROM STEP";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                steps.Add(
                                    new Step(rdr.GetInt32(0), rdr.GetString(1)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return steps;
        }

        public void AddStep(string description)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO STEP VALUES (@description)";
                            cmd.Parameters.Add(new SqlParameter("@description", description));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding recipe");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<StepsList> GetStepsLists(int id_step = -1, int step_number = -1, int id_recipe = -1)
        {
            List<StepsList> stepsLists = new List<StepsList>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //all steps lists
                            if (id_step < 0 && step_number < 0 && id_recipe < 0)
                            {
                                cmd.CommandText = "SELECT * FROM STEPS_LIST";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                stepsLists.Add(
                                    new StepsList(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return stepsLists;
        }
        
        public void AddStepsList(int id_step, int step_number, int id_recipe)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO STEPS_LIST VALUES (@id_step, @step_number, @id_recipe)";
                            cmd.Parameters.Add(new SqlParameter("@id_step", id_step));
                            cmd.Parameters.Add(new SqlParameter("@step_number", step_number));
                            cmd.Parameters.Add(new SqlParameter("@id_recipe", id_recipe));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding steps list");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<IngridientsList> GetIngridientsLists(int id_ingridient = -1, decimal countity = -1, int id_recipe = -1)
        {
            List<IngridientsList> ingridients = new List<IngridientsList>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //all ingridients lists
                            if (id_ingridient < 0 && countity < 0 && id_recipe < 0)
                            {
                                cmd.CommandText = "SELECT * FROM INGRIDIENTS_LIST";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                ingridients.Add(
                                    new IngridientsList(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetDecimal(2), rdr.GetInt32(3)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ingridients;
        }
        
        public void AddIngridientsList(int id_ingridient, int countity, int id_recipe)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            // TODO sprawdzenie czy id_ingridient i id_recipe istnieje
                            cmd.CommandText = "INSERT INTO INGRIDIENTS_LIST VALUES (@id_ingridient, @countity, @id_recipe)";
                            cmd.Parameters.Add(new SqlParameter("@id_ingridient", id_ingridient));
                            cmd.Parameters.Add(new SqlParameter("@id_recipe", id_recipe));
                            cmd.Parameters.Add(new SqlParameter("@countity", countity));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding ingridients list");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<RecipesList> GetRecipesLists(int id_recipe = -1, int id_category = -1)
        {
            List<RecipesList> recipes = new List<RecipesList>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            //all recipes lists
                            if (id_recipe < 0 && id_category < 0)
                            {
                                cmd.CommandText = "SELECT * FROM RECIPES_LIST";
                            }
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                recipes.Add(
                                    new RecipesList(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2)));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return recipes;
        }
        
        public void AddRecipesList(int id_recipe, int id_category)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB")))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    try
                    {
                        using (SqlCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "INSERT INTO RECIPES_LIST VALUES (@id_recipe, @id_category)";
                            cmd.Parameters.Add(new SqlParameter("@id_recipe", id_recipe));
                            cmd.Parameters.Add(new SqlParameter("@id_category", id_category));
                            int i = cmd.ExecuteNonQuery();
                            if (i == -1)
                            {
                                Console.WriteLine("Error adding recipes list");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /*public string test()
        {
            string text = "Jan Kowalski";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM KSIEGA", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    text = connection.State + " ";
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Ksiega ksiega = new Ksiega(rdr.GetInt32(0), rdr.GetInt32(1));
                        text += ksiega.id_ksiega+ " " + ksiega.id_przepisy;
                    }
                    connection.Close();
                    text += " " + connection.State + " ";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return text;
        }*/
    }
}