namespace KsiazkaKucharskaConsole
{
    public class Uzytkownik
    {
        public Uzytkownik(int id, string t, string naz, string log, string pass, string op)
        {
            id_uzytkownik = id;
            typ = t;
            nazwa = naz;
            login = log;
            password = pass;
            opis = op;
        }
        public int id_uzytkownik { get; set; }
        public string typ { get; set; }
        public string nazwa { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string opis { get; set; }
    }
}