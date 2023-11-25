using Service.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer.Job
{
    public class UpdateJobDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Path { get; set; }
        public string? Content { get; set; }
        public string? Parameters { get; set; }
        public  int IntervalId { get; set; } = default!;
        public int Priority { get; set; }
        public int Status { get; set; }
        public int Platform { get; set; }
    }
}
