namespace KsiazkaKucharskaConsole
{
    public class Skladnik
    {
        public Skladnik(int id, string naz, int il, string jedn)
        {
            id_skladnik = id;
            nazwa = naz;
            ilosc = il;
            jednostka = jedn;
        }
        public int id_skladnik { get; set; }
        public string nazwa { get; set; }
        public int ilosc { get; set; }
        public string jednostka { get; set; }
    }
}