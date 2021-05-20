namespace KsiazkaKucharskaConsole
{
    public class Skladnik
    {
        public Skladnik(int id, string naz, string jedn)
        {
            id_skladnik = id;
            nazwa = naz;
            jednostka = jedn;
        }
        public int id_skladnik { get; set; }
        public string nazwa { get; set; }
        public string jednostka { get; set; }
    }
}