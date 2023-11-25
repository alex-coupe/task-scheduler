using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataTransfer.JobResult
{
    public class CreateJobResultDTO
    {
        public int JobId { get; set; }
        public int StatusId { get; set; }
        public string? Message { get; set; }
    }
}
