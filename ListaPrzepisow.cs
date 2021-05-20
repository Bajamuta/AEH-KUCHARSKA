namespace KsiazkaKucharskaConsole
{
    public class ListaPrzepisow
    {
        public ListaPrzepisow(int id, int id_p, int id_k)
        {
            id_lista_przepisow = id;
            id_przepis = id_p;
            id_kategoria = id_k;
        }
        public int id_lista_przepisow { get; set; }
        public int id_przepis { get; set; }
        public int id_kategoria { get; set; }
    }
}