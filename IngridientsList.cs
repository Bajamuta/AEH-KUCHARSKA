namespace KsiazkaKucharskaConsole
{
    public class IngridientsList
    {
        public IngridientsList(int id, int id_ingr, decimal count, int id_rcp)
        {
            id_ingridients_list = id;
            id_ingridient = id_ingr;
            id_recipe = id_rcp;
            countity = count;
        }
        public int id_ingridients_list { get; set; }
        public int id_ingridient { get; set; }
        public int id_recipe { get; set; }
        public decimal countity { get; set; }

    }
}