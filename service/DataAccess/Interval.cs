namespace Service.DataAccess
{
    public class Interval
    {
        public int Id {get; set;}
        public string Name {get; set;} = default!;
        public long IntervalSeconds {get; set;}
    }
}