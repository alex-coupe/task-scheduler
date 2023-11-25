namespace Service.DataAccess{
    public class Job
    {
        public int Id {get; set;}
        public string Name {get; set;} = default!;
        public string? Path { get; set; }
        public string? Content { get; set; }
        public string? Parameters { get; set; }
        public IEnumerable<JobResult>? Results { get; set; }
        public string Creator {get; set;} = default!;
        public DateTime Created {get; set;}
        public DateTime? LastRunTime {get; set;}
        public Interval Interval { get; set; } = default!;
        public DateTime NextRunTime { get; set;}
        public int Priority { get; set; }
        public Status Status { get; set; } = default!;
        public Platform Platform { get; set; } = default!;
    }
}
