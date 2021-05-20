namespace KsiazkaKucharskaConsole
{
    public class Krok
    {
        public Krok(int id, string op)
        {
            id_krok = id;
            opis = op;
        }
        public int id_krok { get; set; }
        public string opis { get; set; }
    }
}