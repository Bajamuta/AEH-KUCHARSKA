namespace KsiazkaKucharskaConsole
{
    public class Book
    {
        public Book(int id, int id_recipes, string nm)
        {
            id_book = id;
            id_recipes_list = id_recipes;
            name = nm;
        }
        public int id_book { get; set; }
        public int id_recipes_list { get; set; }
        public string name { get; set; }
    }
}