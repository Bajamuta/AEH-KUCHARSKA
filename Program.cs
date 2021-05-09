using System;

namespace KsiazkaKucharskaConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            foreach (var ksiega in dataAccess.GetKsiegi()) 
            {
                Console.WriteLine("ksiega nr " + ksiega.id_ksiega + ", index listy przepisow: " + ksiega.id_przepisy);
            }
        }
    }
}