namespace KsiazkaKucharskaConsole
{
    public class RecipesList
    {
        public RecipesList(int id, int id_rcp, int id_cat, int id_bk)
        {
            id_recipes_list = id;
            id_recipe = id_rcp;
            id_category = id_cat;
            id_book = id_bk;
        }
        public int id_recipes_list { get; set; }
        public int id_recipe { get; set; }
        public int id_category { get; set; }
        public int id_book { get; set; }
    }
}