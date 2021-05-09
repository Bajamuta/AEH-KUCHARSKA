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
        
        public List<Ksiega> GetKsiegi()
        {
            List<Ksiega> ksiegi = new List<Ksiega>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM KSIEGA", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ksiegi.Add(new Ksiega(rdr.GetInt32(0), rdr.GetInt32(1)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ksiegi;
        }

        public string test()
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
        }
    }
}