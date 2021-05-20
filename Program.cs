using System;

namespace KsiazkaKucharskaConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            /*foreach (var ksiega in dataAccess.GetKsiegi()) 
            {
                Console.WriteLine("ksiega nr " + ksiega.id_ksiega + ", index listy przepisow: " + ksiega.id_przepisy);
            }*/
            //dataAccess.AddKrok("lorem adsd asd ew r");
            //dataAccess.AddKategoria("kuchnia włoska", "dania kuchni włoskiej");
            //dataAccess.AddUzytkownik("user", "Miranda Waleczna", "waleczna", "Waleczna!123", "Ryby zjada razem z ośćmi");
            //dataAccess.AddSkladnik("koperek", "pęczek");
            //dataAccess.AddPrzepis("spaghetti bolognese", "https://herrbuettner.de/wp-content/uploads/2018/12/spaghetti_chorizo_bolognese_big.jpg", 1);
            dataAccess.AddListaKrokow(1, 1, 1);
        }
    }
}