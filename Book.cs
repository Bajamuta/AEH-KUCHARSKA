namespace KsiazkaKucharskaConsole
{
    public class Book
    {
        public Book(int id, string nm)
        {
            id_book = id;
            name = nm;
        }
        public int id_book { get; set; }
        public string name { get; set; }
    }
}