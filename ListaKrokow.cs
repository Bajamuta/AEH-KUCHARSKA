namespace KsiazkaKucharskaConsole
{
    public class ListaKrokow
    {
        public ListaKrokow(int id, int id_k, int nr_krok)
        {
            id_lista_krokow = id;
            id_krok = id_k;
            numer_kroku = nr_krok;
        }
        public int id_lista_krokow { get; set; }
        public int id_krok { get; set; }
        public int numer_kroku { get; set; }
    }
}