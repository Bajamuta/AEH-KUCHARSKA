namespace KsiazkaKucharskaConsole
{
    public class Ingridient
    {
        public Ingridient(int id, string nm, string jn)
        {
            id_ingridient = id;
            name = nm;
            junit = jn;
        }
        public int id_ingridient { get; set; }
        public string name { get; set; }
        public string junit { get; set; }
    }
}