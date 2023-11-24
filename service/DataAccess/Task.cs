namespace Service.DataAccess{
    public class Task
    {
        public int Id {get; set;}
        public string Name {get; set;} = default!;
        public string Job {get; set;} = default!;
        public string Creator {get; set;} = default!;
        public DateTime Created {get; set;}
        public DateTime? LastRunTime {get; set;}
        public Interval? Interval { get; set;}
        public DateTime NextRunTime { get; set;}
        public int Priority { get; set; }
    }
}
