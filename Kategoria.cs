namespace KsiazkaKucharskaConsole
{
    public class Kategoria
    {
        public Kategoria(int id, string naz, string op)
        {
            id_kategoria = id;
            nazwa = naz;
            opis = op;
        }
        public int id_kategoria { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
    }
}