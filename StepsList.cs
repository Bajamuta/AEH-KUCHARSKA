namespace KsiazkaKucharskaConsole
{
    public class StepsList
    {
        public StepsList(int id, int id_st, int step_nr, int id_rcp)
        {
            id_steps_list = id;
            id_step = id_st;
            step_number = step_nr;
            id_recipe = id_rcp;
        }
        public int id_steps_list { get; set; }
        public int id_step { get; set; }
        public int step_number { get; set; }
        public int id_recipe { get; set; }
    }
}