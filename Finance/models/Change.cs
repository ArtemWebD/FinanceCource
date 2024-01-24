namespace Finance.models
{
    public class Change
    {
        public int id { get; set; }
        public float value { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public int wallet { get; set; }
    }
}
