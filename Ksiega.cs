namespace KsiazkaKucharskaConsole
{
    public class Ksiega
    {
        public Ksiega(int id, int id_p, string nazw)
        {
            id_ksiega = id;
            id_przepisy = id_p;
            nazwa = nazw;
        }
        public int id_ksiega { get; set; }
        public int id_przepisy { get; set; }
        public string nazwa { get; set; }
    }
}