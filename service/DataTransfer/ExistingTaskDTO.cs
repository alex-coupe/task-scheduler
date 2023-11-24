using Service.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.DataTransfer
{
    public class ExistingTaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Job { get; set; } = default!;
        public string Creator { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? LastRunTime { get; set; }
        public Interval? Interval { get; set; }
        public DateTime NextRunTime { get; set; }
        public int Priority { get; set; }
    }
}
