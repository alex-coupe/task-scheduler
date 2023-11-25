using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataAccess
{
    public class JobResult
    {
        public int Id { get; set; }
        public Job Job { get; set; } = default!;
        public Status Status { get; set; } = default!;
        public string? Message { get; set; }
    }
}
