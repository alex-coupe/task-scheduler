namespace Service.DataAccess{
    class Task
    {
        public int Id {get; set;}
        public string Name {get; set;} = default!;
        public string Job {get; set;} = default!;
        public string Creator {get; set;} = default!;
        public DateTime Created {get; set;}
        public DateTime RunTime {get; set;}

    }
}
