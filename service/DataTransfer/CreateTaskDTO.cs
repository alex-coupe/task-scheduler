using Service.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer
{
    public class CreateTaskDTO
    {
        public string Name { get; set; } = default!;
        public Func<System.Threading.Tasks.Task> Job { get; set; } = default!;
        public string Creator { get; set; } = default!;
        public DateTime Created { get; set; }
        public Interval? Interval { get; set; }
        public DateTime NextRunTime { get; set; }
        public int Priority { get; set; }
    }
}
