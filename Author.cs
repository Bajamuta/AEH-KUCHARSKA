namespace KsiazkaKucharskaConsole
{
    public class Author
    {
        public Author(int id, string tp, string nm, string log, string pass, string desc)
        {
            id_author = id;
            type = tp;
            name = nm;
            login = log;
            password = pass;
            description = desc;
        }
        public int id_author { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string description { get; set; }
    }
}