namespace KsiazkaKucharskaConsole
{
    public class Step
    {
        public Step(int id, string desc)
        {
            id_step = id;
            description = desc;
        }
        public int id_step { get; set; }
        public string description { get; set; }
    }
}