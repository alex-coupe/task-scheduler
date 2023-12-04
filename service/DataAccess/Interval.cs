namespace Service.DataAccess
{
    public class Interval
    {
        public int Id {get; set;}
        public IEnumerable<Job>? Jobs { get; set; }
        public string Second { get; set; } = default!;
        public string Minute {get; set; } = default!;
        public string Hour {get; set; } = default!;
        public string Day {get; set; } = default!;
        public string Month {get; set; } = default!;
    }
}