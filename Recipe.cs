namespace KsiazkaKucharskaConsole
{
    public class Recipe
    {
        public Recipe(int id, string nm, string phot, int id_auth)
        {
            id_recipe = id;
            name = nm;
            photo = phot;
            id_author = id_auth;
        }
        public int id_recipe { get; set; }
        public string name { get; set; }
        public string photo { get; set; }
        public int id_author { get; set; }
    }
}