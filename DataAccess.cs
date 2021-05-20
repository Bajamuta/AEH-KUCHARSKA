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

        public void AddKsiega(string nazwa, List<Przepis> przepisy)
        {
            
        }

        public List<Przepis> GetPrzepis()
        {
            List<Przepis> przepisy = new List<Przepis>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM PRZEPIS", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        przepisy.Add(
                            new Przepis(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetInt32(3)));
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

        public void AddPrzepis(string nazwa, string zdjecie, int id_autor, int id_lista_krokow)
        {
            
        }

        public List<Skladnik> GetSkladnik()
        {
            List<Skladnik> skladniki = new List<Skladnik>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM SKLADNIK", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        skladniki.Add(
                            new Skladnik(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return skladniki;
        }

        public void AddSkladnik(string nazwa, string jednostka)
        {
            string cmdtext = "INSERT INTO SKLADNIK VALUES (\'" + nazwa + "', '" + jednostka + "')";
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

        public List<Uzytkownik> GetUzytkownicy()
        {
            List<Uzytkownik> uzytkownicy = new List<Uzytkownik>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM UZYTKOWNIK", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        uzytkownicy.Add(
                            new Uzytkownik(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return uzytkownicy;
        }

        public void AddUzytkownik(string typ, string nazwa, string login, string password, string opis)
        {
            string cmdtext = "INSERT INTO UZYTKOWNIK VALUES (\'" + typ + "', '" + nazwa + "', '" + login + "', '" + password + "', '" + opis + "')";
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
        
        public List<Kategoria> GetKategorie()
        {
            List<Kategoria> kategorie = new List<Kategoria>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM KATEGORIA", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        kategorie.Add(
                            new Kategoria(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return kategorie;
        }

        public void AddKategoria(string nazwa, string opis)
        {
            string cmdtext = "INSERT INTO KATEGORIA VALUES (\'" + nazwa + "', '" + opis + "')";
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
        
        public List<Krok> GetKroki()
        {
            List<Krok> kroki = new List<Krok>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM KROK", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        kroki.Add(
                            new Krok(rdr.GetInt32(0), rdr.GetString(1)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return kroki;
        }

        public void AddKrok(string opis)
        {
            string cmdtext = "INSERT INTO KROK VALUES (\'" + opis + "')";
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
        
        public List<ListaKrokow> GetListaKrokow()
        {
            List<ListaKrokow> lista_krokow = new List<ListaKrokow>();
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("Select * FROM LISTA_KROKOW", connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lista_krokow.Add(
                            new ListaKrokow(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetInt32(2)));
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return lista_krokow;
        }
        
        public void AddListaKrokow(int id_krok, int numer_kroku)
        {
            string cmdtext = "INSERT INTO KROK VALUES (\'" + id_krok + "', '" + numer_kroku + "')";
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