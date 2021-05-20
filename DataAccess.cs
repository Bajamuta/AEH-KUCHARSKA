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
        private SqlConnection connection = new SqlConnection(Helper.CnnVal("KUCHARSKA_DB"));
        
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM BOOK", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        books.Add(new Book(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2)));
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

        public void AddKsiega(int id_recipes_list, string name)
        {
            string cmdtext = "INSERT INTO BOOK VALUES (\'" +  id_recipes_list + "', '" + name + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd dodawanie ksiega?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Recipe> GetRecipe(string name = "", int id_author = -1)
        {
            List<Recipe> przepisy = new List<Recipe>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select [ID], [NAME], [PHOTO], [ID_AUTHOR] FROM RECIPE WHERE [NAME] = @name", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        przepisy.Add(
                            new Recipe(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return przepisy;
        }

        public void AddRecipe(string name, string photo, int id_author)
        {
            string cmdtext = "INSERT INTO RECIPE VALUES (\'" + name + "', '" + photo + "', '" + id_author + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd dodawanie przepis?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Ingridient> GetIngridient()
        {
            List<Ingridient> ingridients = new List<Ingridient>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM INGRIDIENT", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ingridients.Add(
                            new Ingridient(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                    }
                    connection.Close();
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
            string cmdtext = "INSERT INTO INGRIDIENT VALUES (\'" + name + "', '" + junit + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd dodawanie skladnik?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM AUTHOR", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        authors.Add(
                            new Author(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5)));
                    }
                    connection.Close();
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
            string cmdtext = "INSERT INTO AUTHOR VALUES (\'" + type + "', '" + name + "', '" + login + "', '" + password + "', '" + description + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd dodawanie uzytkownik?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<Category> GetKategorie()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM CATEGORY", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        categories.Add(
                            new Category(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                    }
                    connection.Close();
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
            string cmdtext = "INSERT INTO CATEGORY VALUES (\'" + name + "', '" + description + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd dodawanie kategoria?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<Step> GetSteps()
        {
            List<Step> steps = new List<Step>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM STEP", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        steps.Add(
                            new Step(rdr.GetInt32(0), rdr.GetString(1)));
                    }
                    connection.Close();
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
            string cmdtext = "INSERT INTO STEP VALUES (\'" + description + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd krok?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<StepsList> GetStepsLists()
        {
            List<StepsList> stepsLists = new List<StepsList>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM STEPS_LIST", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        stepsLists.Add(
                            new StepsList(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3)));
                    }
                    connection.Close();
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
            string cmdtext = "INSERT INTO STEPS_LIST VALUES (\'" + id_step + "', '" + step_number + "', '" + id_recipe + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd tworzenie listy krokow?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<IngridientsList> GetIngridientsLists()
        {
            List<IngridientsList> ingridients = new List<IngridientsList>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM INGRIDIENTS_LIST", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ingridients.Add(
                            new IngridientsList(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetInt32(3)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ingridients;
        }
        
        public void AddIngridientsList(int id_ingridient, int id_recipe, int countity)
        {
            string cmdtext = "INSERT INTO INGRIDIENTS_LIST VALUES (\'" + id_ingridient + "', '" + id_recipe + "', '" + countity + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd tworzenie listy krokow?");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public List<RecipesList> GetRecipesLists()
        {
            List<RecipesList> recipes = new List<RecipesList>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM RECIPES_LIST", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        recipes.Add(
                            new RecipesList(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2)));
                    }
                    connection.Close();
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
            string cmdtext = "INSERT INTO RECIPES_LIST VALUES (\'" + id_recipe + "', '" + id_category + "')";
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(cmdtext, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    int i = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (i == -1)
                    {
                        Console.WriteLine("Błąd tworzenie listy przepisow?");
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