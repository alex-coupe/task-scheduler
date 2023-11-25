using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer.JobResult
{
    public class ReadJobResultDTO
    {
        public string Status { get; set; } = default!;
        public string? Message { get; set; }
    }
}
