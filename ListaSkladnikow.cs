namespace KsiazkaKucharskaConsole
{
    public class ListaSkladnikow
    {
        public ListaSkladnikow(int id, int id_s, int id_p, int il)
        {
            id_lista_skladnkow = id;
            id_skladnik = id_s;
            id_przepis = id_p;
            ilosc = il;
        }
        public int id_lista_skladnkow { get; set; }
        public int id_skladnik { get; set; }
        public int id_przepis { get; set; }
        public int ilosc { get; set; }

    }
}