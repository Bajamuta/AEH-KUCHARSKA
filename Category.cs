namespace KsiazkaKucharskaConsole
{
    public class Category
    {
        public Category(int id, string nm, string desc)
        {
            id_category = id;
            name = nm;
            description = desc;
        }
        public int id_category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}