namespace KsiazkaKucharskaConsole
{
    public class Przepis
    {
        public Przepis(int id, string naz, string zdj, int id_aut)
        {
            id_przepis = id;
            nazwa = naz;
            zdjecie = zdj;
            id_autor = id_aut;
        }
        public int id_przepis { get; set; }
        public string nazwa { get; set; }
        public string zdjecie { get; set; }
        public int id_autor { get; set; }
    }
}