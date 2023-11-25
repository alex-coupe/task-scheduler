using Service.DataAccess;
using Service.DataTransfer.JobResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer.Job
{
    public class ReadJobDTO
    {
        public string Name { get; set; } = default!;
        public string? Path { get; set; }
        public string? Content { get; set; }
        public string? Parameters { get; set; }
        public IEnumerable<ReadJobResultDTO> Results { get; set; } = default!;
        public string Creator { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? LastRunTime { get; set; }
        public string Interval { get; set; } = default!;
        public DateTime NextRunTime { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; } = default!;
        public string Platform { get; set; } = default!;
    }
}
