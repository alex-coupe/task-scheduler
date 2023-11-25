namespace Service.DataAccess
{
    public class Interval
    {
        public int Id {get; set;}
        public IEnumerable<Job>? Jobs { get; set; }
        public int Second {get; set;}
        public int Minute {get; set;}
        public int Hour {get; set;}
        public int Day {get; set;}
        public int Month {get; set;}
        public int Year {get; set;}
    }
}