namespace KsiazkaKucharskaConsole
{
    public class Przepis
    {
        public Przepis(int id, string naz, string zdj, int id_aut, int id_l_k)
        {
            id_przepis = id;
            nazwa = naz;
            zdjecie = zdj;
            id_autor = id_aut;
            id_lista_krokow = id_l_k;
        }
        public int id_przepis { get; set; }
        public string nazwa { get; set; }
        public string zdjecie { get; set; }
        public int id_autor { get; set; }
        public int id_lista_krokow { get; set; }
    }
}